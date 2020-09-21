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
    public class SeatController : Controller
    {
        private readonly SeatRepository db;
        private readonly SectionRepository sectionRepository;
        private readonly FlightRepository flights;
        [HttpGet]
        public ActionResult Index(int FlightId)
        {
            var model = db.AllSeatsForFlight(FlightId);
            return View(model);
        }

        public SeatController()
        {
            db = new SeatRepository();
            sectionRepository = new SectionRepository();
            flights = new FlightRepository();
        }
        // GET: Seat
        [HttpGet]
        public ActionResult Create(int id)
        {
            var model = new SeatSectionCreateViewModel()
            {
                FlightId = id,
                SeatClass = GetSeatClassDropDown()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatSectionCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //SeatClass seatClass;

                //Enum.TryParse(model.SeatClass.ToList().Where(m => m.Value == model.SeatClassId.ToString()).FirstOrDefault().Text, out seatClass);
                try
                {
                    db.AddSeatsForFlight(model.FlightId, model.row, model.col, model.SeatClassId);

                }
                catch(Exception e)
                {
                    return RedirectToAction("Error", new {message = e.Message });
                }
                return RedirectToAction("Index", "Flight");
            }
            model.SeatClass = GetSeatClassDropDown();
            return View(model);
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult ChangeStatus(int seatId)
        {
            var model = db.Retreive(seatId);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(SeatViewModel seat)
        {
            if (ModelState.IsValid)
            {
                db.BookSeat(seat.SeatId);
                return RedirectToAction("Index", "Seat", new { FlightId = seat.FlightId.ToString() });
            }
            return View();
        }

        public List<SelectListItem> GetSeatClassDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = sectionRepository.Retreive();
            foreach (var section in lm)
            {
                ls.Add(new SelectListItem() { Text = section.SeatClassName, Value = section.SectionId.ToString() });
            }
            return ls;
        }
    }
}