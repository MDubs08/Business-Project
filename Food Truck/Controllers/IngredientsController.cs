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
    public class IngredientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ingredients
        public ActionResult Index()
        {
            var ingredient = db.Ingredient.Include(i => i.Food_Item).Include(i => i.Inventory);
            return View(ingredient.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredient.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name");
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,InventoryID,Food_ItemID")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredient.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", ingredient.Food_ItemID);
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", ingredient.InventoryID);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredient.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", ingredient.Food_ItemID);
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", ingredient.InventoryID);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,InventoryID,Food_ItemID")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", ingredient.Food_ItemID);
            ViewBag.InventoryID = new SelectList(db.Inventory, "ID", "Name", ingredient.InventoryID);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredient.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredient.Find(id);
            db.Ingredient.Remove(ingredient);
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
