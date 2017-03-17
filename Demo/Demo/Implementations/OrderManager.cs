using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Demo.Models;


namespace Demo.Implementations
{
    public class OrderManager : UserManager<ApplicationUser>, IOrderManager
    {
        IProductStore productStore;
        public OrderManager(IProductStore prodStr, IUserStore<ApplicationUser> store) : base(store)
        {
            productStore = prodStr;
        }
        public bool MakeOrder(string userId, int[] selectedProducts)
        {
            List<Product> orderProducts = new List<Product>();

            foreach (int pid in selectedProducts)
            {
                orderProducts.Add(productStore.FindById(pid));
            }

            Order userOrder = new Order
            {
                Products = orderProducts,
                CreatedOn = DateTime.Now
            };

            ApplicationUser currentUser = this.FindById(userId);

            currentUser.Orders.Add(userOrder);

            try
            {
                this.Update(currentUser);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}