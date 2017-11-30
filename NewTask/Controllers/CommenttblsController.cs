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
    public class CommenttblsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Commenttbls
        public ActionResult Index()
        {
            var comments = db.comments.Include(c => c.proj).Include(c => c.tasktbl);
            return View(comments.ToList());
        }

        // GET: Commenttbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commenttbl commenttbl = db.comments.Find(id);
            if (commenttbl == null)
            {
                return HttpNotFound();
            }
            return View(commenttbl);
        }

        // GET: Commenttbls/Create
        public ActionResult Create()
        {
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name");
            ViewBag.Task_id = new SelectList(db.task_tables, "Task_id", "Task_Name");
            return View();
        }

        // POST: Commenttbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comment_id,Pro_id,Task_id,comment")] Commenttbl commenttbl)
        {
            if (ModelState.IsValid)
            {
                db.comments.Add(commenttbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", commenttbl.Pro_id);
            ViewBag.Task_id = new SelectList(db.task_tables, "Task_id", "Task_Name", commenttbl.Task_id);
            return View(commenttbl);
        }

        // GET: Commenttbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commenttbl commenttbl = db.comments.Find(id);
            if (commenttbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", commenttbl.Pro_id);
            ViewBag.Task_id = new SelectList(db.task_tables, "Task_id", "Task_Name", commenttbl.Task_id);
            return View(commenttbl);
        }

        // POST: Commenttbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comment_id,Pro_id,Task_id,comment")] Commenttbl commenttbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commenttbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", commenttbl.Pro_id);
            ViewBag.Task_id = new SelectList(db.task_tables, "Task_id", "Task_Name", commenttbl.Task_id);
            return View(commenttbl);
        }

        // GET: Commenttbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commenttbl commenttbl = db.comments.Find(id);
            if (commenttbl == null)
            {
                return HttpNotFound();
            }
            return View(commenttbl);
        }

        // POST: Commenttbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commenttbl commenttbl = db.comments.Find(id);
            db.comments.Remove(commenttbl);
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
