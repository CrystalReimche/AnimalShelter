namespace AnimalShelter.Migrations
{
    using AnimalShelter.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimalShelter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AnimalShelter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //context.Pets.AddOrUpdate(x => x.Pet_ID,
            //    new Pet { Pet_ID = 1, Species_Type = Species_Type.Dog, Breed = "German Shepherd", Name = "Cloe", Age = "2 years", Gender = Gender.Female, Neutered = true, Coat_Color = "Black/Tan", Date_Arrived_In_Shelter = DateTime.Parse("03/30/2018") },

            //    new Pet { Pet_ID = 2, Species_Type = Species_Type.Dog, Breed = "Border Collie/Lab", Name = "Mel", Age = "1.5 years", Gender = Gender.Male, Neutered = true, Coat_Color = "Black/White/Tan", Date_Arrived_In_Shelter = DateTime.Parse("3/24/2018") },

            //    new Pet { Pet_ID = 3, Species_Type = Species_Type.Dog, Breed = "Mastiff", Name = "Lucas", Age = "4 years", Gender = Gender.Male, Neutered = true, Coat_Color = "Brindle", Date_Arrived_In_Shelter = DateTime.Parse("8/29/2017"), Notes = "Needs experienced owner with this breed, no cats, no other dogs, no small children. He is a very big boy." },

            //    new Pet { Pet_ID = 4, Species_Type = Species_Type.Dog, Breed = "Malamute X", Name = "Amber", Age = "2 years", Gender = Gender.Female, Spayed = true, Coat_Color = "Red/Tan/White", Date_Arrived_In_Shelter = DateTime.Parse("2/6/2018") },

            //    new Pet { Pet_ID = 5, Species_Type = Species_Type.Dog, Breed = "Mixed", Name = "Agnes", Age = "4 months", Gender = Gender.Female, Spayed = false, Coat_Color = "Brindle", Date_Arrived_In_Shelter = DateTime.Parse("4/15/2018") },

            //    new Pet { Pet_ID = 6, Species_Type = Species_Type.Cat, Breed = "Domestic Long Haired", Name = "", Age = "Adult", Gender = Gender.Male, Neutered = true, Coat_Color = "Black with white spot on chest", Date_Arrived_In_Shelter = DateTime.Parse("5/24/2016"), Notes = "Nice big cat ready for a great home.", },

            //    new Pet { Pet_ID = 7, Species_Type = Species_Type.Cat, Breed = "Domestic Long Haired", Name = "", Age = "Adult", Gender = Gender.Male, Neutered = true, Coat_Color = "Black", Date_Arrived_In_Shelter = DateTime.Parse("5/24/2016"), Notes = "He is an interesting cat. He has a short naturally kinked tail. He is a bit shy but likes to be petted." },

            //    new Pet { Pet_ID = 8, Species_Type = Species_Type.Cat, Breed = "Manx", Name = "", Age = "Adult", Gender = Gender.Female, Spayed = true, Coat_Color = "Gray Tabby and White", Date_Arrived_In_Shelter = DateTime.Parse("3/31/2016"), Notes = "For a Manx she is very sweet." },

            //    new Pet { Pet_ID = 9, Species_Type = Species_Type.Cat, Breed = "Domestic Short Haired", Name = "", Age = "Kitten", Gender = Gender.Male, Neutered = true, Coat_Color = "tabby", Date_Arrived_In_Shelter = DateTime.Parse("2/19/2016"), Notes = "This little guy loves to wrestle. He is very active and would provide good entertainment to the right person." }
            //);

        }
    }
}
