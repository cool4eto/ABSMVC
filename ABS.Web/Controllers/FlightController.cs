using ABS.Data;
using ABS.Entities;
using ABS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABSMVC.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightRepository db;
        private readonly AirlineRepository airlines;
        private readonly AirportRepository airports;
        public FlightController()
        {
            db = new FlightRepository();
            airlines = new AirlineRepository();
            airports = new AirportRepository();
        }
        // GET: Flight
        public ActionResult Index(string sortOrder, string originAirport, string destinationAirport)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var model = db.Retreive();
            if (!String.IsNullOrEmpty(originAirport))
            {
                model = model.Where(f => f.OriginAirport == originAirport);
            }
            if(!String.IsNullOrEmpty(destinationAirport))
            {
                model = model.Where(f => f.DestinationAirport == destinationAirport);
            }
            switch (sortOrder)
            {
                case "Date":
                    model = model.OrderBy(s => s.Date);
                    break;
                default:
                    model = model.OrderByDescending(s => s.Date);
                    break;
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new FlightCreateViewModel();
            model.Airlines = GetAirlinesDropDown();
            model.OriginAirports = GetAirportsDropDown();
            model.DestinationAirports = GetAirportsDropDown();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.AddNewFlight(flight);
                }
                catch(Exception e)
                {
                    return RedirectToAction("Error", new { message = e.Message });
                }
               return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }


        public List<SelectListItem> GetAirlinesDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = airlines.Retreive();
            foreach (var airline in lm)
            {
                ls.Add(new SelectListItem() { Text = airline.Name, Value = airline.AirlineId.ToString() });
            }
            return ls;
        }

        public List<SelectListItem> GetAirportsDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = airports.Retreive();
            foreach (var airport in lm)
            {
                ls.Add(new SelectListItem() { Text = airport.Name, Value = airport.AirportId.ToString() });
            }
            return ls;
        }

    }
}