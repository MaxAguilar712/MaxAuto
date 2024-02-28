using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaxAuto.Models
{
    public class Car
    {
        
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Name { get; set; }

        
        public string Transmission { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        
        public int Mileage { get; set; }

        
        public string ImageUrl { get; set; }


        public int Worth { get; set; }

    }
}