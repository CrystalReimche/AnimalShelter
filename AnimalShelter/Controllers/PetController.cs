using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class PetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ShowDogs()
        {
            var dogs = db.Pets.Where(d => d.Species_Type == Species_Type.Dog).ToList();
            return View(dogs);
        }


        public ActionResult ShowCats()
        {
            var cats = db.Pets.Where(c => c.Species_Type == Species_Type.Cat).ToList();
            return View(cats);
        }

        





        




        // GET: Pet
        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }



        



        // GET: Pet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet upload, HttpPostedFileBase UploadImage)
        {
            
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/bmp" || UploadImage.ContentType == "image/gif" || UploadImage.ContentType == "image/jpeg")
                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/" + UploadImage.FileName);
                        upload.Photo = UploadImage.FileName;
                    }
                    else
                        return View();
                }
                else
                {
                    TempData["Success"] = "Upload successful";
                    return View();
                }

                db.Pets.Add(upload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }




       

        // GET: Pet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pet_ID,Breed,Species_Type,Name,Age,Gender,Coat_Color,Date_Arrived_In_Shelter,Spayed,Neutered,Notes")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
