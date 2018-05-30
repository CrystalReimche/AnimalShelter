using AnimalShelter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

[assembly: OwinStartupAttribute(typeof(AnimalShelter.Startup))]
namespace AnimalShelter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
            //CreatePets();
        }

        //Creating default users and admin users to be logged in
        private void CreateRolesandUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Creating a default User and Admin role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }

            try
            {
                // Create default Admin user
                var user = new ApplicationUser
                {
                    Email = "admin@pupper.go",
                    UserName = "admin@pupper.go",
                };
                string userPassword = "Password1!";

                var chkUser = UserManager.Create(user, userPassword);

                //Adding default user to admin role
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            catch (System.Exception)
            {

            }

            //Creating User Role
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                roleManager.Create(role);
            }
            try
            {
                var user = new ApplicationUser()
                {
                    Email = "volunteer@pupper.com",
                    UserName = "volunteer@pupper.com",
                };

                string userPassword = "Password1!";
                var chkUser = UserManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "User");
                }
            }
            catch (System.Exception)
            {

            }
        }

        //private void CreatePets()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var pets = new List<Pet>
        //    {
        //        new Pet { Species_Type = Species_Type.Dog, Breed = "German Shepherd", Name = "Cloe", Age = "2 years", Gender = Gender.Female, Neutered = true, Coat_Color = "Black/Tan", Date_Arrived_In_Shelter = DateTime.Parse("03/30/2018") },

        //        new Pet { Species_Type = Species_Type.Dog, Breed = "Border Collie/Lab", Name = "Mel", Age = "1.5 years", Gender = Gender.Male, Neutered = true, Coat_Color = "Black/White/Tan", Date_Arrived_In_Shelter = DateTime.Parse("3/24/2018") },

        //        new Pet { Species_Type = Species_Type.Dog, Breed = "Mastiff", Name = "Lucas", Age = "4 years", Gender = Gender.Male, Neutered = true, Coat_Color = "Brindle", Date_Arrived_In_Shelter = DateTime.Parse("8/29/2017"), Notes = "Needs experienced owner with this breed, no cats, no other dogs, no small children. He is a very big boy." },

        //        new Pet{ Species_Type = Species_Type.Dog, Breed = "Malamute X", Name = "Amber", Age = "2 years", Gender = Gender.Female, Spayed = true, Coat_Color = "Red/Tan/White", Date_Arrived_In_Shelter = DateTime.Parse("2/6/2018") },

        //        new Pet { Species_Type = Species_Type.Dog, Breed = "Mixed", Name = "Agnes", Age = "4 months", Gender = Gender.Female, Spayed = false, Coat_Color = "Brindle", Date_Arrived_In_Shelter = DateTime.Parse("4/15/2018") },

        //        new Pet { Species_Type = Species_Type.Cat, Breed = "Domestic Long Haired", Name = "", Age = "Adult", Gender = Gender.Male, Neutered = true, Coat_Color = "Black with white spot on chest", Date_Arrived_In_Shelter = DateTime.Parse("5/24/2016"), Notes = "Nice big cat ready for a great home.", },

        //        new Pet { Species_Type = Species_Type.Cat, Breed = "Domestic Long Haired", Name = "", Age = "Adult", Gender = Gender.Male, Neutered = true, Coat_Color = "Black", Date_Arrived_In_Shelter = DateTime.Parse("5/24/2016"), Notes = "He is an interesting cat. He has a short naturally kinked tail. He is a bit shy but likes to be petted." },

        //        new Pet { Species_Type = Species_Type.Cat, Breed = "Manx", Name = "", Age = "Adult", Gender = Gender.Female, Spayed = true, Coat_Color = "Gray Tabby and White", Date_Arrived_In_Shelter = DateTime.Parse("3/31/2016"), Notes = "For a Manx she is very sweet." },

        //        new Pet { Species_Type = Species_Type.Cat, Breed = "Domestic Short Haired", Name = "", Age = "Kitten", Gender = Gender.Male, Neutered = true, Coat_Color = "tabby", Date_Arrived_In_Shelter = DateTime.Parse("2/19/2016"), Notes = "This little guy loves to wrestle. He is very active and would provide good entertainment to the right person." }
        //    };


            
        //}





    }
}
