using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace spinFrameMvc.Models
{
    public class Car
    {
        [Key]
        public string CarPlate { get; set; }
        public CarColor Color { get; set; }
        public CarManufactor Manufactor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}