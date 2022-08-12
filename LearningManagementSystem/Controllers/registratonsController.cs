using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class registratonsController : Controller
    {
        private DatabasefileEntities db = new DatabasefileEntities();

        // GET: registratons
        public ActionResult Index()
        {
            var registratons = db.registratons.Include(r => r.cours).Include(r => r.department).Include(r => r.Student).Include(r => r.Teacher);
            return View(registratons.ToList());
        }

        // GET: registratons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registraton registraton = db.registratons.Find(id);
            if (registraton == null)
            {
                return HttpNotFound();
            }
            return View(registraton);
        }

        // GET: registratons/Create
        public ActionResult Create()
        {
            ViewBag.Cid = new SelectList(db.courses, "Cid", "Cname");
            ViewBag.did = new SelectList(db.departments, "did", "DepartmentName");
            ViewBag.stdid = new SelectList(db.Students, "stdid", "StdName");
            ViewBag.Tid = new SelectList(db.Teachers, "Tid", "TName");
            return View();
        }

        // POST: registratons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Regid,Cid,Tid,stdid,did")] registraton registraton)
        {
            if (ModelState.IsValid)
            {
                db.registratons.Add(registraton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cid = new SelectList(db.courses, "Cid", "Cname", registraton.Cid);
            ViewBag.did = new SelectList(db.departments, "did", "DepartmentName", registraton.did);
            ViewBag.stdid = new SelectList(db.Students, "stdid", "StdName", registraton.stdid);
            ViewBag.Tid = new SelectList(db.Teachers, "Tid", "TName", registraton.Tid);
            return View(registraton);
        }

        // GET: registratons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registraton registraton = db.registratons.Find(id);
            if (registraton == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cid = new SelectList(db.courses, "Cid", "Cname", registraton.Cid);
            ViewBag.did = new SelectList(db.departments, "did", "DepartmentName", registraton.did);
            ViewBag.stdid = new SelectList(db.Students, "stdid", "StdName", registraton.stdid);
            ViewBag.Tid = new SelectList(db.Teachers, "Tid", "TName", registraton.Tid);
            return View(registraton);
        }

        // POST: registratons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Regid,Cid,Tid,stdid,did")] registraton registraton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registraton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cid = new SelectList(db.courses, "Cid", "Cname", registraton.Cid);
            ViewBag.did = new SelectList(db.departments, "did", "DepartmentName", registraton.did);
            ViewBag.stdid = new SelectList(db.Students, "stdid", "StdName", registraton.stdid);
            ViewBag.Tid = new SelectList(db.Teachers, "Tid", "TName", registraton.Tid);
            return View(registraton);
        }

        // GET: registratons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registraton registraton = db.registratons.Find(id);
            if (registraton == null)
            {
                return HttpNotFound();
            }
            return View(registraton);
        }

        // POST: registratons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registraton registraton = db.registratons.Find(id);
            db.registratons.Remove(registraton);
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
