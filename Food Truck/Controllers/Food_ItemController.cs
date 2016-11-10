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
    public class Food_ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Food_Item
        public ActionResult Index()
        {
            return View(db.Food_Item.ToList());
        }

        // GET: Food_Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Item food_Item = db.Food_Item.Find(id);
            if (food_Item == null)
            {
                return HttpNotFound();
            }
            return View(food_Item);
        }

        // GET: Food_Item/Create
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Sale_Price")] Food_Item food_Item)
        {
            if (ModelState.IsValid)
            {
                db.Food_Item.Add(food_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food_Item);
        }

        // GET: Food_Item/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Item food_Item = db.Food_Item.Find(id);
            if (food_Item == null)
            {
                return HttpNotFound();
            }
            return View(food_Item);
        }

        // POST: Food_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Sale_Price")] Food_Item food_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food_Item);
        }

        // GET: Food_Item/Delete/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Item food_Item = db.Food_Item.Find(id);
            if (food_Item == null)
            {
                return HttpNotFound();
            }
            return View(food_Item);
        }

        // POST: Food_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Item food_Item = db.Food_Item.Find(id);
            db.Food_Item.Remove(food_Item);
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
