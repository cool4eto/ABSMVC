using ABS.Data;
using ABS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABSMVC.Controllers
{
    public class AirlineController : Controller
    {
        private readonly AirlineRepository db;
        public AirlineController()
        {
            db = new AirlineRepository();
        }

        // GET: Airline
        public ActionResult Index()
        {
            var model = db.Retreive();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Airline airline)
        {
            if(ModelState.IsValid)
            {
                db.AddNewAirline(airline);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}