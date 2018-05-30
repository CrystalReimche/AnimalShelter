using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelter.Controllers
{
    public class FileUploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View();
        }







        //[HttpPost]
        //public ActionResult Index(Pet upload, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var guid = Guid.NewGuid().ToString();
        //            var path = Path.Combine(Server.MapPath("~/Uploads"), guid + fileName);
        //            file.SaveAs(path);
        //            string fl = path.Substring(path.LastIndexOf("\\"));
        //            string[] split = fl.Split('\\');
        //            string newpath = split[1];
        //            string imagepath = "~/Uploads/" + newpath;
        //            upload.Photo = imagepath;
        //            db.Pets.Add(upload);
        //            db.SaveChanges();
        //        }
        //        TempData["Success"] = "Upload successful";



        //        //db.Pets.Add(pet);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Index(Pet upload, HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var guid = Guid.NewGuid().ToString();
        //        var path = Path.Combine(Server.MapPath("~/Uploads"), guid + fileName);
        //        file.SaveAs(path);
        //        string fl = path.Substring(path.LastIndexOf("\\"));
        //        string[] split = fl.Split('\\');
        //        string newpath = split[1];
        //        string imagepath = "~/Uploads/" + newpath;
        //        upload.Length = imagepath;
        //        db.Pets.Add(upload);
        //        db.SaveChanges();
        //    }
        //    TempData["Success"] = "Upload successful";
        //    return RedirectToAction("Index", "Pet");
        //}

    }
}