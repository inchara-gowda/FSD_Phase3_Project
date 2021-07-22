using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Models
{
    public class Order
    {
        public int id { get; set; }
        //[Required(ErrorMessage = "Please select a product")]
        public int ProductID { get; set; }
        //public int CustomerID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public int CustomerPhoneNumber { get; set; }
        //public virtual Customer Course { get; set; }
        //public virtual Product Product { get; set; }
    }
}