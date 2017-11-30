using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewTask;
using NewTask.Models;

namespace NewTask.Controllers
{
    [Authorize]

    public class TasktblsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Tasktbls
        public ActionResult Index()
        {
            var task_tables = db.task_tables.Include(t => t.proj).Include(t => t.user);
            return View(task_tables.ToList());
        }

        // GET: Tasktbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasktbl tasktbl = db.task_tables.Find(id);
            if (tasktbl == null)
            {
                return HttpNotFound();
            }
            return View(tasktbl);
        }

        // GET: Tasktbls/Create
        public ActionResult Create()
        {
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name");
            ViewBag.User_Id = new SelectList(db.users, "User_id", "User_name");
            return View();
        }

        // POST: Tasktbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_id,Task_Name,Task_description,Pro_id,User_Id,Due_date,Priority")] Tasktbl tasktbl)
        {
            if (ModelState.IsValid)
            {
                db.task_tables.Add(tasktbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", tasktbl.Pro_id);
            ViewBag.User_Id = new SelectList(db.users, "User_id", "User_name", tasktbl.User_Id);
            return View(tasktbl);
        }

        // GET: Tasktbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasktbl tasktbl = db.task_tables.Find(id);
            if (tasktbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", tasktbl.Pro_id);
            ViewBag.User_Id = new SelectList(db.users, "User_id", "User_name", tasktbl.User_Id);
            return View(tasktbl);
        }

        // POST: Tasktbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_id,Task_Name,Task_description,Pro_id,User_Id,Due_date,Priority")] Tasktbl tasktbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasktbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", tasktbl.Pro_id);
            ViewBag.User_Id = new SelectList(db.users, "User_id", "User_name", tasktbl.User_Id);
            return View(tasktbl);
        }

        // GET: Tasktbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasktbl tasktbl = db.task_tables.Find(id);
            if (tasktbl == null)
            {
                return HttpNotFound();
            }
            return View(tasktbl);
        }

        // POST: Tasktbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasktbl tasktbl = db.task_tables.Find(id);
            db.task_tables.Remove(tasktbl);
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
