using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Interfaces;
using Demo.Models;
using System.Data.Entity;

namespace Demo.Implementations
{
    public class ProductStore : IProductStore
    {
        private ApplicationDbContext db;

        public ProductStore(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public bool Create(Product prod)
        {
            try
            {
                db.Product.Add(prod);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Product prod)
        {
            try
            {
                db.Product.Remove(prod);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product FindById(int id)
        {
            return db.Product.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return db.Product.ToList();
        }

        public bool Update(Product prod)
        {
            try
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}