using DotNet_Phase3_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.ViewModels
{
    public class OrderViewModel
    {
        public Product ProducttoOrder { get; set; }
        public Order OrderDetails { get; set; }

    }
}