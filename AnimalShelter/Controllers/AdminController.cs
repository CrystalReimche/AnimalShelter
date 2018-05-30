using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalShelter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AnimalShelter.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult Index()
        {


            return View();
        }


        // GET: Admin
        public ActionResult ViewUsers()
        {
            //return View(db.Users.ToList());
            List<UserViewModel> modelLst = new List<UserViewModel>();
            var role = db.Roles.Include(x => x.Users).ToList();

            foreach (var r in role)
            {
                foreach (var u in r.Users)
                {
                    var usr = db.Users.Find(u.UserId);
                    var obj = new UserViewModel
                    {
                        UserName = usr.UserName,
                        Email = usr.Email,
                        RoleName = r.Name,
                        FirstName = usr.FirstName,
                        LastName = usr.LastName,
                        AddressOne = usr.AddressOne,
                        AddressTwo = usr.AddressTwo,
                        City = usr.City,
                        State = usr.State,
                        Zip = usr.Zip,
                    };

                    modelLst.Add(obj);
                }

            }
            return View(modelLst);


        }


        public ActionResult CreateUser()
        {
            AssignRole();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            string firstName = form["inputFirstName"];
            string lastName = form["inputLastName"];
            string userName = form["inputUserName"];
            string email = form["inputEmail"];
            string address = form["inputAddress"];
            string address2 = form["inputAddress2"];
            string city = form["inputCity"];
            string state = form["inputState"];
            string zip = form["inputZip"];

            var user = new ApplicationUser()
            {
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                AddressOne = address,
                AddressTwo = address2,
                City = city,
                State = state,
                Zip = zip,

            };

            var newUser = UserManager.Create(user/*, password*/);
            AssignRole(form);
            return View("Index");
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRole(FormCollection form)
        {
            string roleName = form["RoleName"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Creating a default User and Admin role
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };
                roleManager.Create(role);
            }

            return View("Index");
        }

        public ActionResult AssignRole()
        {
            ViewBag.Roles = db.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string usrname = form["inputUserName"];
            string rolname = form["RoleName"];

            var user = db.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            userManager.AddToRole(user.Id, rolname);

            return View("Index");
        }


      













        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,AddressOne,AddressTwo,City,State,Zip,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,AddressOne,AddressTwo,City,State,Zip,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
