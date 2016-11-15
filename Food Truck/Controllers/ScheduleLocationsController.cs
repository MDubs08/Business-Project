using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food_Truck.Models;
using GoogleMaps.LocationServices;

namespace Food_Truck.Controllers
{
    public class ScheduleLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleLocations
        public ActionResult Index()
        {
            var scheduleLocation = db.ScheduleLocation.Include(s => s.Location).Include(s => s.Schedule).Include(s => s.Truck);
            return View(scheduleLocation.ToList());
        }

        public ActionResult Schedule()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Owner"))
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            var scheduleLocation = db.ScheduleLocation.Include(s => s.Location).Include(s => s.Schedule).Include(s => s.Truck);
            return View(scheduleLocation.ToList());
        }

        // GET: ScheduleLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleLocation scheduleLocation = db.ScheduleLocation.Find(id);
            if (scheduleLocation == null)
            {
                return HttpNotFound();
            }
            return View(scheduleLocation);
        }

        // GET: ScheduleLocations/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name");
            ViewBag.ScheduleID = new SelectList(db.Schedule, "ID", "ID");
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name");
            return View();
        }

        // POST: ScheduleLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TruckID,LocationID,ScheduleID")] ScheduleLocation scheduleLocation)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleLocation.Add(scheduleLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", scheduleLocation.LocationID);
            ViewBag.ScheduleID = new SelectList(db.Schedule, "ID", "ID", scheduleLocation.ScheduleID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", scheduleLocation.TruckID);
            return View(scheduleLocation);
        }

        // GET: ScheduleLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleLocation scheduleLocation = db.ScheduleLocation.Find(id);
            if (scheduleLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", scheduleLocation.LocationID);
            ViewBag.ScheduleID = new SelectList(db.Schedule, "ID", "ID", scheduleLocation.ScheduleID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", scheduleLocation.TruckID);
            return View(scheduleLocation);
        }

        // POST: ScheduleLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TruckID,LocationID,ScheduleID")] ScheduleLocation scheduleLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Location, "ID", "Name", scheduleLocation.LocationID);
            ViewBag.ScheduleID = new SelectList(db.Schedule, "ID", "ID", scheduleLocation.ScheduleID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", scheduleLocation.TruckID);
            return View(scheduleLocation);
        }

        // GET: ScheduleLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleLocation scheduleLocation = db.ScheduleLocation.Find(id);
            if (scheduleLocation == null)
            {
                return HttpNotFound();
            }
            return View(scheduleLocation);
        }

        // POST: ScheduleLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleLocation scheduleLocation = db.ScheduleLocation.Find(id);
            db.ScheduleLocation.Remove(scheduleLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
