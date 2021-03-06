﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrchardsOnTheBrazos.Models;

namespace OrchardsOnTheBrazos.Controllers
{
    public class AnnouncementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Announcements
        [Authorize(Roles="Resident")]
        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        public ActionResult _Announcements()
        {
            return PartialView(db.Announcements.ToList());
        }
        [Authorize(Roles ="Resident")]
        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details",announcements);
        }
        [Authorize(Roles = "Resident")]
        // GET: Announcements/Create
        public ActionResult _Create()
        {
            return PartialView();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Date,Announcement")] Announcements announcements)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home", announcements);
        }
        [Authorize(Roles = "Resident")]
        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", announcements);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Date,Announcement")] Announcements announcements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(announcements);
        }
        [Authorize(Roles = "Resident")]
        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcements = db.Announcements.Find(id);
            if (announcements == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete",announcements);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcements announcements = db.Announcements.Find(id);
            db.Announcements.Remove(announcements);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
