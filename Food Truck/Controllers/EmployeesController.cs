using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food_Truck.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Food_Truck.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Truck);
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Create()
        {
           // ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            //ViewBag.TruckId = new SelectList(db.Truck, "ID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,LastName,EmailAddress,AssignedPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                string email = employee.EmailAddress.ToString();
                ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = new ApplicationUser { UserName = email, Email = email };
                var result = await UserManager.CreateAsync(user, employee.AssignedPassword);
                await UserManager.AddToRoleAsync(user.Id, "Employee");
                ApplicationUser employeeUser = db.Users.FirstOrDefault(x => x.UserName == email);
                employee.ApplicationUserId = employeeUser.Id;
                employee.ApplicationUser = employeeUser;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            ViewBag.TruckId = new SelectList(db.Truck, "ID", "Name", employee.TruckId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            ViewBag.TruckId = new SelectList(db.Truck, "ID", "Name", employee.TruckId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmailAddress,AssignedPassword,ApplicationUserId,TruckId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            ViewBag.TruckId = new SelectList(db.Truck, "ID", "Name", employee.TruckId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "Admin, Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
