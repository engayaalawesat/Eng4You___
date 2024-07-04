using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eng4You.Models;
using Microsoft.AspNetCore.Hosting.Server;
using WebApplication1.Models;
using WebLanguages.Controllers;

namespace Eng4You.Controllers
{
    [HandleError]
    public class ProgrammesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programmes
        public ActionResult Index()
        {
            return View(db.Programmes.ToList());
        }

        // GET: Programmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmes programmes = db.Programmes.Find(id);
            if (programmes == null)
            {
                return HttpNotFound();
            }
            return View(programmes);
        }

        // GET: Programmes/Create
        public ActionResult Create()
        {
            ViewBag.NemSecProgramList = new SelectList(db.NemSecPrograms, "Id", "NamSecProgram");
            return View();
        }

        // POST: Programmes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase fileUpload, [Bind(Include = "Id,FileName,NemSecProgramId")] Programmes programmes)
        {
            try
            {
                if (fileUpload != null && fileUpload.ContentLength > 0 && Path.GetExtension(fileUpload.FileName).Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string path = Path.Combine(Server.MapPath("~/UploadFileProgram"), fileName);
                    fileUpload.SaveAs(path);

                    programmes.FileName = fileName;
                    programmes.FilePath = path;

                    if (ModelState.IsValid)
                    {
                        db.Programmes.Add(programmes);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please upload a valid ZIP file.");
                }
            }
            catch (Exception ex)
            {
                // Log the error (you can use a logging framework like log4net or NLog)
                System.Diagnostics.Debug.WriteLine(ex.Message);
                ModelState.AddModelError("", "An error occurred while uploading the file. Please try again.");
            }

            ViewBag.NemSecProgramList = new SelectList(db.NemSecPrograms, "Id", "NamSecProgram", programmes.NemSecProgram.Id);
            return View(programmes);
        }

        // GET: Programmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmes programmes = db.Programmes.Find(id);
            if (programmes == null)
            {
                return HttpNotFound();
            }
            return View(programmes);
        }

        // POST: Programmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,FilePath")] Programmes programmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programmes);
        }

        // GET: Programmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programmes programmes = db.Programmes.Find(id);
            if (programmes == null)
            {
                return HttpNotFound();
            }
            return View(programmes);
        }

        // POST: Programmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programmes programmes = db.Programmes.Find(id);
            db.Programmes.Remove(programmes);
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

        public ActionResult DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string filePath = Path.Combine(Server.MapPath("~/UploadFileProgram"), fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Zip, fileName);
        }
    }
}
