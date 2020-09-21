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
    public class AirportController : Controller
    {
        private readonly AirportRepository db;
        public AirportController()
        {
            db = new AirportRepository();
        }
        // GET: Airport
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
        public ActionResult Create(Airport airport)
        {
            if(ModelState.IsValid)
            {
                db.AddNewAirport(airport);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}