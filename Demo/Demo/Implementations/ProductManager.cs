using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Models;
using Demo.Interfaces;

namespace Demo.Implementations
{
    public class ProductManager : IProductManager 
    {
        private IProductStore store;
        public ProductManager(IProductStore prodStore)
        {
            store = prodStore;
        }

        public IEnumerable<Product> GetList()
        {
            return store.GetList();
        }

        public IEnumerable<Product> GetSaleItems(decimal discount, int threshold)
        {
            if (discount < 0 || discount > 1)
                throw new ArgumentException("Percentage needs to be between 0 and 1");

            if (threshold < 0)
                throw new ArgumentException("Order count thereshold needs to be non-negative");

            IEnumerable<Product> allProducts = GetList();

            List<Product> discountedProducts = new List<Product>();

            foreach (Product prod in allProducts)
            {
                int countDaysBelowThreshold = 0;

                List<DateTime> daysSinceAdded = new List<DateTime>();

                daysSinceAdded.Add(prod.AddedOn.AddDays(1).Date);
                while (daysSinceAdded.Last().Date < DateTime.Today)
                {
                    daysSinceAdded.Add(daysSinceAdded.Last().AddDays(1).Date);
                }

                countDaysBelowThreshold = daysSinceAdded.Count(d => prod.Orders.Count(o => o.CreatedOn.Date == d) < threshold);

                prod.Price -= countDaysBelowThreshold * discount * prod.Price;

                discountedProducts.Add(prod);
            }

            return discountedProducts;
        }
    }
}