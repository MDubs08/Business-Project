using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food_Truck.Models;

namespace Food_Truck.Controllers
{
    public class TruckInventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TruckInventories
        public ActionResult Index()
        {
            var truckInventory = db.TruckInventory.Include(t => t.Inventory).Include(t => t.Truck);
            return View(truckInventory.ToList());
        }

        // GET: TruckInventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckInventory truckInventory = db.TruckInventory.Find(id);
            if (truckInventory == null)
            {
                return HttpNotFound();
            }
            return View(truckInventory);
        }

        // GET: TruckInventories/Create
        public ActionResult Create()
        {
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name");
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name");
            return View();
        }

        // POST: TruckInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Quantity,InventoryID,TruckID")] TruckInventory truckInventory)
        {
            if (ModelState.IsValid)
            {
                db.TruckInventory.Add(truckInventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", truckInventory.InventoryID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", truckInventory.TruckID);
            return View(truckInventory);
        }

        // GET: TruckInventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckInventory truckInventory = db.TruckInventory.Find(id);
            if (truckInventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", truckInventory.InventoryID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", truckInventory.TruckID);
            return View(truckInventory);
        }

        // POST: TruckInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Quantity,InventoryID,TruckID")] TruckInventory truckInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truckInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", truckInventory.InventoryID);
            ViewBag.TruckID = new SelectList(db.Truck, "ID", "Name", truckInventory.TruckID);
            return View(truckInventory);
        }

        // GET: TruckInventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckInventory truckInventory = db.TruckInventory.Find(id);
            if (truckInventory == null)
            {
                return HttpNotFound();
            }
            return View(truckInventory);
        }

        // POST: TruckInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TruckInventory truckInventory = db.TruckInventory.Find(id);
            db.TruckInventory.Remove(truckInventory);
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
