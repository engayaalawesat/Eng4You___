using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eng4You.Migrations;
using Eng4You.Models;
using WebApplication1.Models;
using AddBooks = Eng4You.Models.AddBooks;
using WebLanguages.Controllers;

namespace Eng4You.Controllers
{
    [HandleError]
    public class AddBooksController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddBooks
        public ActionResult Index()
        {
            return View(db.AddBooks.ToList());
        }

        public ActionResult ComingSoon()
        {
            return View();
        }

        // GET: AddBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBooks addBooks = db.AddBooks.Find(id);
            if (addBooks == null)
            {
                return HttpNotFound();
            }
            return View(addBooks);
        }

        // GET: AddBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddBooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddBooks addBooks, HttpPostedFileBase ImageFileBookEN, HttpPostedFileBase ImageFileBookAR, HttpPostedFileBase ImageFileBookTR, HttpPostedFileBase ImageFileBookBack)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Create", addBooks);
            }
            else
            {
                if (ImageFileBookEN != null)
                {
                    addBooks.FrontBookImageinEnglish = ImageFileBookEN.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookEN.FileName);
                    ImageFileBookEN.SaveAs(path);
                }

                if (ImageFileBookAR != null)
                {
                    addBooks.FrontBookImageinArabic = ImageFileBookAR.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookAR.FileName);
                    ImageFileBookAR.SaveAs(path);
                }

                if (ImageFileBookTR != null)
                {
                    addBooks.FrontBookImageinTurkish = ImageFileBookTR.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookTR.FileName);
                    ImageFileBookTR.SaveAs(path);
                }

                if (ImageFileBookBack != null)
                {
                    addBooks.BackBookImage = ImageFileBookBack.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookBack.FileName);
                    ImageFileBookBack.SaveAs(path);
                }
                db.AddBooks.Add(addBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: AddBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBooks addBooks = db.AddBooks.Find(id);
            if (addBooks == null)
            {
                return HttpNotFound();
            }
            return View(addBooks);
        }

        // POST: AddBooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddBooks addBooks, HttpPostedFileBase ImageFileBookEN, HttpPostedFileBase ImageFileBookAR, HttpPostedFileBase ImageFileBookTR, HttpPostedFileBase ImageFileBookBack)
        {
            if (ModelState.IsValid)
            {
                var existingAddBooks = db.AddBooks.Find(addBooks.Id);

                if (existingAddBooks == null)
                {
                    return HttpNotFound();
                }

                if (ImageFileBookEN != null)
                {
                    addBooks.FrontBookImageinEnglish = ImageFileBookEN.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookEN.FileName);
                    ImageFileBookEN.SaveAs(path);
                }
                else
                {
                    addBooks.FrontBookImageinEnglish = existingAddBooks.FrontBookImageinEnglish;
                }

                if (ImageFileBookAR != null)
                {
                    addBooks.FrontBookImageinArabic = ImageFileBookAR.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookAR.FileName);
                    ImageFileBookAR.SaveAs(path);
                }
                else
                {
                    addBooks.FrontBookImageinArabic = existingAddBooks.FrontBookImageinArabic;
                }

                if (ImageFileBookTR != null)
                {
                    addBooks.FrontBookImageinTurkish = ImageFileBookTR.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookTR.FileName);
                    ImageFileBookTR.SaveAs(path);
                }
                else
                {
                    addBooks.FrontBookImageinTurkish = existingAddBooks.FrontBookImageinTurkish;
                }

                if (ImageFileBookBack != null)
                {
                    addBooks.BackBookImage = ImageFileBookBack.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFileBookBack.FileName);
                    ImageFileBookBack.SaveAs(path);
                }
                else
                {
                    addBooks.BackBookImage = existingAddBooks.BackBookImage;
                }

                db.Entry(existingAddBooks).State = EntityState.Detached; // Detach the existing entry
                db.Entry(addBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addBooks);
        }

        // GET: AddBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBooks addBooks = db.AddBooks.Find(id);
            if (addBooks == null)
            {
                return HttpNotFound();
            }
            return View(addBooks);
        }

        // POST: AddBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddBooks addBooks = db.AddBooks.Find(id);
            db.AddBooks.Remove(addBooks);
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
