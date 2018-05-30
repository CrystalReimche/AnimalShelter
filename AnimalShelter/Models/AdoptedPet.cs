using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalShelter.Models
{
    public class AdoptedPet
    {
        [Key]
        public int Adopted_Pet_ID { get; set; } // PK

        public DateTime Date_Adopted { get; set; }

        public string Notes { get; set; }

        public bool Thank_You_Letter_Sent { get; set; }


        public Adopter Adopter_ID { get; set; } // FK of Adopter
        public virtual Adopter Adopter { get; set; }


        public Pet Pet_ID { get; set; } // FK of Pet
        public virtual List<Pet> Pets { get; set; }
    }
}