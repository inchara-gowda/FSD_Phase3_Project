using DotNet_Phase3_Project.Data;
using DotNet_Phase3_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet_Phase3_Project.Services
{
    public class SqlOrderRepo : IRepo<Order>
    {
        private storeDbContext _context;
        public SqlOrderRepo(storeDbContext context)
        {
            _context = context;
        }
        public bool Add(Order item)
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

        public bool Delete(Order item)
        {
            try
            {
                Order order = Get(item.id);
                if (order != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(Order item)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            // any entity match this id
            if (_context.Orders.Count(x => x.id == id) > 0)
            {
                return _context.Orders.FirstOrDefault(x => x.id == id);
            }
            return null;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }
    }
}