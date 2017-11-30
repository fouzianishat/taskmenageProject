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

    public class User_assign_projectController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: User_assign_project
        public ActionResult Index()
        {
            var user_assigend_projects = db.user_assigend_projects.Include(u => u.project).Include(u => u.user);
            return View(user_assigend_projects.ToList());
        }

        // GET: User_assign_project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_assign_project user_assign_project = db.user_assigend_projects.Find(id);
            if (user_assign_project == null)
            {
                return HttpNotFound();
            }
            return View(user_assign_project);
        }

        // GET: User_assign_project/Create
        public ActionResult Create()
        {
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name");
            ViewBag.User_id = new SelectList(db.users, "User_id", "User_name");
            return View();
        }

        // POST: User_assign_project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAssignid,User_id,Pro_id")] User_assign_project user_assign_project)
        {
            if (ModelState.IsValid)
            {
                db.user_assigend_projects.Add(user_assign_project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", user_assign_project.Pro_id);
            ViewBag.User_id = new SelectList(db.users, "User_id", "User_name", user_assign_project.User_id);
            return View(user_assign_project);
        }

        // GET: User_assign_project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_assign_project user_assign_project = db.user_assigend_projects.Find(id);
            if (user_assign_project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", user_assign_project.Pro_id);
            ViewBag.User_id = new SelectList(db.users, "User_id", "User_name", user_assign_project.User_id);
            return View(user_assign_project);
        }

        // POST: User_assign_project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAssignid,User_id,Pro_id")] User_assign_project user_assign_project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_assign_project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pro_id = new SelectList(db.projects, "Pro_id", "Project_Name", user_assign_project.Pro_id);
            ViewBag.User_id = new SelectList(db.users, "User_id", "User_name", user_assign_project.User_id);
            return View(user_assign_project);
        }

        // GET: User_assign_project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_assign_project user_assign_project = db.user_assigend_projects.Find(id);
            if (user_assign_project == null)
            {
                return HttpNotFound();
            }
            return View(user_assign_project);
        }

        // POST: User_assign_project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_assign_project user_assign_project = db.user_assigend_projects.Find(id);
            db.user_assigend_projects.Remove(user_assign_project);
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
