using DotNet_Phase3_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Services
{
    public class MockProductRepo : IRepo<Product>
    {

        List<Product> _products;
        public MockProductRepo()
        {
            _products = new List<Product>() 
    { 

                new Product()
                {
                    ProductID = 0,
                    Name = "Microsoft servise pro",
                    Category = "LabTop",
                    Price = 2000,
                    Image = "https://res.cloudinary.com/dxfq3iotg/image/upload/v1562074043/234.png",
                    Description = "Microsoft servise pro drgkm kfgk "
                },
                new Product()
                {
                   ProductID = 1,
                   Name = "Tosheba",
                   Category = "LabTop",
                   Price = 2000,
                   Image = "https://res.cloudinary.com/dxfq3iotg/image/upload/v1562074043/234.png",
                   Description = "vise pro drgkm kfgk "
                },
        };

    }

        public bool Add(Product item)
        {

            try
            {
                Product product = item;
                product.ProductID = _products.Max(x => x.ProductID) + 1;
                _products.Add(item);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Console.WriteLine(id);
            return _products.FirstOrDefault(x=>x.ProductID == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }
    }
}