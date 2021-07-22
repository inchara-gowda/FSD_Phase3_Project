using DotNet_Phase3_Project.Data;
using DotNet_Phase3_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Services
{
    public class SqlProductRepo : IRepo<Product>
    {
        private storeDbContext _context;

        public SqlProductRepo(storeDbContext context)
        {
            _context = context;
        }


        public bool Add(Product item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Product item)
        {
            try
            {
                Product product = Get(item.ProductID);
                    _context.Remove(item);
                    _context.SaveChanges();
                    return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            // any entity match this id
            if (_context.Products.Count(x=> x.ProductID == id) > 0)
            {
                return _context.Products.FirstOrDefault(x => x.ProductID == id);
            }
            return null;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }
    }
}