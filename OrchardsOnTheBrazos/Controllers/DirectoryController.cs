﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrchardsOnTheBrazos.Models;

namespace OrchardsOnTheBrazos.Controllers
{
    public class DirectoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Directories
        public ActionResult Index()
        {
            //var directory = db.Directories.Include(c => c.DirectoryDetail);

            return RedirectToAction("DirectoryDetails", "Directory");
        }

        public ActionResult DirectoryDetails()
        {
            return View(db.DirectoryDetails.ToList());
        }

        // GET: Directories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // GET: Directories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectoryId")] Models.Directory directory)
        {
            if (ModelState.IsValid)
            {
                List<DirectoryDetail> directoryDetails = new List<DirectoryDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        DirectoryDetail directoryDetail = new DirectoryDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        directoryDetails.Add(directoryDetail);

                        var path = Path.Combine(Server.MapPath("~/Content/Files/"), directoryDetail.Id + directoryDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                directory.DirectoryDetail = directoryDetails;
                db.Directories.Add(directory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directory);
        }

        // GET: Directories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // POST: Directories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectoryId")] Models.Directory directory)
        {
            if (ModelState.IsValid)
                if (ModelState.IsValid)
                {
                    //New Files
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            DirectoryDetail directoryDetail = new DirectoryDetail()
                            {
                                FileName = fileName,
                                Extension = Path.GetExtension(fileName),
                                Id = Guid.NewGuid(),
                                DirectoryId = directory.DirectoryId
                            };
                            var path = Path.Combine(Server.MapPath("~/Content/Files/"), directoryDetail.Id + directoryDetail.Extension);
                            file.SaveAs(path);

                            db.Entry(directoryDetail).State = EntityState.Added;
                        }
                    }
                    db.Entry(directory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(directory);
        }

        // GET: Directories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return HttpNotFound();
            }
            return View(directory);
        }

        // POST: Directories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Directory directory = db.Directories.Find(id);
            //delete files from the file system

            foreach (var item in directory.DirectoryDetail)
            {
                String path = Path.Combine(Server.MapPath("~/Content/Files/"), item.Id + item.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            db.Directories.Remove(directory);
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