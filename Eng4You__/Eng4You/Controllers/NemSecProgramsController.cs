using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eng4You.Models;
using WebApplication1.Models;
using WebLanguages.Controllers;

namespace Eng4You.Controllers
{
    [HandleError]
    public class NemSecProgramsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NemSecPrograms
        public ActionResult Index()
        {
            return View(db.NemSecPrograms.ToList());
        }

        // GET: NemSecPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NemSecProgram nemSecProgram = db.NemSecPrograms.Find(id);
            if (nemSecProgram == null)
            {
                return HttpNotFound();
            }
            return View(nemSecProgram);
        }

        // GET: NemSecPrograms/Create
        public ActionResult Create()
        {
            var nemSecPrograms = db.NemSecPrograms.ToList(); // Fetching the list of NemSecPrograms
            ViewBag.NemSecProgramList = new SelectList(nemSecPrograms, "Id", "NamSecProgram"); // Passing the list to the view
            return View();
        }

        // POST: NemSecPrograms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NamSecProgram")] NemSecProgram nemSecProgram)
        {
            if (ModelState.IsValid)
            {
                db.NemSecPrograms.Add(nemSecProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var nemSecPrograms = db.NemSecPrograms.ToList(); // Re-fetching the list in case of a validation error
            ViewBag.NemSecProgramList = new SelectList(nemSecPrograms, "Id", "NamSecProgram"); // Re-passing the list to the view
            return View(nemSecProgram);
        }

        // GET: NemSecPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NemSecProgram nemSecProgram = db.NemSecPrograms.Find(id);
            if (nemSecProgram == null)
            {
                return HttpNotFound();
            }
            return View(nemSecProgram);
        }

        // POST: NemSecPrograms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NamSecProgram")] NemSecProgram nemSecProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nemSecProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nemSecProgram);
        }

        // GET: NemSecPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NemSecProgram nemSecProgram = db.NemSecPrograms.Find(id);
            if (nemSecProgram == null)
            {
                return HttpNotFound();
            }
            return View(nemSecProgram);
        }

        // POST: NemSecPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NemSecProgram nemSecProgram = db.NemSecPrograms.Find(id);
            db.NemSecPrograms.Remove(nemSecProgram);
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
