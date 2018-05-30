using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalShelter.Models
{
    public class Adopter
    {
        [Key]
        public int Adopter_ID { get; set; } // PK

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual List<AdoptedPet> Adopted_Pets { get; set; }
    }
}