using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
    }
}