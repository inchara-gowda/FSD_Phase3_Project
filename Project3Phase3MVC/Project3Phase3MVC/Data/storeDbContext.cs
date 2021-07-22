
using DotNet_Phase3_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Data
{
    public class storeDbContext : DbContext
    {
        public storeDbContext(DbContextOptions options) :base(options)
        {
        }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=store1;Integrated Security=true;");
            //base.OnConfiguring(optionsBuilder);
        }

    }
}