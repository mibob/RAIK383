using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Models;
using Demo.Interfaces;

namespace Demo.Implementations
{
    public class OrderStore : IOrderStore
    {
        private ApplicationDbContext db;
        public OrderStore(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public bool Create(string userId, int[] productsIds)
        {
            List<Product> orderProducts = db.Product.Where(p => productsIds.Contains(p.Id)).ToList();

            ApplicationUser currentUser = db.Users.Find(userId);

            currentUser.Orders.Add(new Models.Order
            {
                Products = orderProducts,
                User = currentUser,
                CreatedOn = DateTime.Now
            });
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}