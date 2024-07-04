using System;
using System.IO;
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
    public class AddMajorSectionsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddMajorSections
        public ActionResult Index()
        {
            return View(db.All_Books.ToList());
        }

        // GET: AddMajorSections/Details/5
        public ActionResult Details(string nameofmajor, int? id)
        {
            if (string.IsNullOrEmpty(nameofmajor) || id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Assuming db is your database context
            AddMajorSection addMajorSection = db.All_Books.FirstOrDefault(m => m.NameofMajor == nameofmajor && m.Id == id);

            if (addMajorSection == null)
            {
                return HttpNotFound();
            }

            return View(addMajorSection);
        }

        // GET: AddMajorSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddMajorSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddMajorSection addMajorSection, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Create", addMajorSection);
            }
            else
            {
                if (ImageFile != null)
                {
                    addMajorSection.MajorImage = ImageFile.FileName;
                    string path = Server.MapPath("~/Uploads/" + ImageFile.FileName);
                    ImageFile.SaveAs(path);
                }
                db.All_Books.Add(addMajorSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: AddMajorSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddMajorSection addMajorSection = db.All_Books.Find(id);
            if (addMajorSection == null)
            {
                return HttpNotFound();
            }
            return View(addMajorSection);
        }

        // POST: AddMajorSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddMajorSection addMajorSection, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingImage = db.All_Books.Find(addMajorSection.Id);

                    if (existingImage == null)
                    {
                        return HttpNotFound();
                    }

                    // Check if a new image is uploaded
                    if (ImageFile != null && ImageFile.ContentLength > 0)
                    {
                        // Remove the existing image file
                        var imagePath = Path.Combine(Server.MapPath("~/Uploads"), existingImage.MajorImage);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        // Generate a unique filename to avoid conflicts
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageFile.FileName);

                        // Save the new image file
                        string newImagePath = Path.Combine(Server.MapPath("~/Uploads"), uniqueFileName);
                        ImageFile.SaveAs(newImagePath);

                        // Update the model with the new image file name
                        existingImage.MajorImage = uniqueFileName;
                    }

                    // Use TryUpdateModel for model binding, excluding the "upload" property
                    if (TryUpdateModel(existingImage, "", new string[] { "MajorImage", "NameofMajor" , "NameofMajorinArabic", "NameofMajorinTurkish" }))
                    {
                        existingImage.RowVersion = BitConverter.GetBytes(DateTime.Now.Ticks);
                        db.SaveChanges();
                        return RedirectToAction("Index", new { id = existingImage.Id });
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the changes: " + ex.Message);
                }
            }

            return View(addMajorSection);
        }

        // GET: AddMajorSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddMajorSection addMajorSection = db.All_Books.Find(id);
            if (addMajorSection == null)
            {
                return HttpNotFound();
            }
            return View(addMajorSection);
        }

        // POST: AddMajorSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddMajorSection addMajorSection = db.All_Books.Find(id);
            db.All_Books.Remove(addMajorSection);
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
