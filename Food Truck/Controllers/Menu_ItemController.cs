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
    public class Menu_ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menu_Item
        public ActionResult Index()
        {
            var menu_Item = db.Menu_Item.Include(m => m.Food_Item).Include(m => m.Menu);
            return View(menu_Item.ToList());
        }

        public ActionResult Owner()
        {
            var menu_Item = from x in db.Menu_Item select x;
            return View(menu_Item.ToList());
        }

        // GET: Menu_Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.Menu_Item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            return View(menu_Item);
        }

        // GET: Menu_Item/Create
        public ActionResult Create()
        {
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name");
            ViewBag.MenuID = new SelectList(db.Menu, "ID", "Name");
            return View();
        }

        // POST: Menu_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Food_ItemID,MenuID")] Menu_Item menu_Item)
        {
            if (ModelState.IsValid)
            {
                db.Menu_Item.Add(menu_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", menu_Item.Food_ItemID);
            ViewBag.MenuID = new SelectList(db.Menu, "ID", "Name", menu_Item.MenuID);
            return View(menu_Item);
        }

        // GET: Menu_Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.Menu_Item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", menu_Item.Food_ItemID);
            ViewBag.MenuID = new SelectList(db.Menu, "ID", "Name", menu_Item.MenuID);
            return View(menu_Item);
        }

        // POST: Menu_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Food_ItemID,MenuID")] Menu_Item menu_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Food_ItemID = new SelectList(db.Food_Item, "ID", "Name", menu_Item.Food_ItemID);
            ViewBag.MenuID = new SelectList(db.Menu, "ID", "Name", menu_Item.MenuID);
            return View(menu_Item);
        }

        // GET: Menu_Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.Menu_Item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            return View(menu_Item);
        }

        // POST: Menu_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu_Item menu_Item = db.Menu_Item.Find(id);
            db.Menu_Item.Remove(menu_Item);
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
