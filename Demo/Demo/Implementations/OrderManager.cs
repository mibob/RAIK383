using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Implementations
{
    public class OrderManager : IOrderManager
    {
        private IOrderStore orderStore; 
        public OrderManager(IOrderStore ordStr)
        {
            orderStore = ordStr;
        }
        public bool CreateOrder(string userId, int[] productIds)
        {
            return orderStore.Create(userId, productIds);
        }
    }
}