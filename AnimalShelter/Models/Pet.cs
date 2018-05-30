using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalShelter.Models
{
    public enum Gender { Male, Female }

    public enum Species_Type { Dog, Cat }

    public class Pet
    {
        [Key]
        public int Pet_ID { get; set; }

        public string Breed { get; set; }

        public Species_Type Species_Type { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public Gender Gender { get; set; }

        public string Coat_Color { get; set; }

        public DateTime Date_Arrived_In_Shelter { get; set; }

        public AdoptedPet Date_Adopted { get; set; }

        public bool Spayed { get; set; }

        public bool Neutered { get; set; }

        public string Notes { get; set; }

        public string Photo { get; set; }


        public virtual AdoptedPet Adopted_Pets { get; set; }
    }
}