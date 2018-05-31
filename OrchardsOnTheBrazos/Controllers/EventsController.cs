using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OrchardsOnTheBrazos.Models;

namespace OrchardsOnTheBrazos.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventPost,EventPicture")] Event @event)
        {


            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["EventPicture"];

                @event.EventId = Guid.NewGuid();

                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png")
                    {
                        TempData["Errormsg"] = "Image File Extension is Not valid";
                        return View();
                    }
                    else
                    {
                        @event.EventPicture = @event.EventId + fi.Extension;
                        file.SaveAs(Server.MapPath("~/Content/Temp/" + @event.EventId + fi.Extension));
                    }
                }

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventPost,EventPicture")] Event @event, Guid? id)
        {
            var oldFile = @event.EventId;
            TempData["OldFile"] = oldFile;
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["EventPicture"];
                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != ".png")
                    {
                        TempData["Errormsg"] = "Image File Extension is Not valid";
                        return View();
                    }
                    else
                    {
                        string fullPath = Request.MapPath("~/Content/Temp/" + @event.EventId + fi.Extension);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        @event.EventPicture = @event.EventId + fi.Extension;

                        file.SaveAs(Server.MapPath("~/Content/Temp/" + @event.EventId + fi.Extension));

                        @event.EventPicture = @event.EventId + fi.Extension;
                    }
                }

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                //Response.Redirect(Request.Url.AbsoluteUri);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
