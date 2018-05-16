using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrchardsOnTheBrazos;

namespace OrchardsOnTheBrazos.Controllers
{
    public class EmailVerificationsController : Controller
    {
        private Entities db = new Entities();

        // GET: EmailVerifications
        public ActionResult Index()
        {
            return View(db.EmailVerifications.ToList());
        }

        // GET: EmailVerifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVerification emailVerification = db.EmailVerifications.Find(id);
            if (emailVerification == null)
            {
                return HttpNotFound();
            }
            return View(emailVerification);
        }

        // GET: EmailVerifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailVerifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailList")] EmailVerification emailVerification)
        {
            if (ModelState.IsValid)
            {
                db.EmailVerifications.Add(emailVerification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailVerification);
        }

        // GET: EmailVerifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVerification emailVerification = db.EmailVerifications.Find(id);
            if (emailVerification == null)
            {
                return HttpNotFound();
            }
            return View(emailVerification);
        }

        // POST: EmailVerifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailList")] EmailVerification emailVerification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailVerification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailVerification);
        }

        // GET: EmailVerifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVerification emailVerification = db.EmailVerifications.Find(id);
            if (emailVerification == null)
            {
                return HttpNotFound();
            }
            return View(emailVerification);
        }

        // POST: EmailVerifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailVerification emailVerification = db.EmailVerifications.Find(id);
            db.EmailVerifications.Remove(emailVerification);
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
