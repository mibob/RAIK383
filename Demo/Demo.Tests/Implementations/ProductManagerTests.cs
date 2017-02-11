using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Interfaces;
using Moq;
using Demo.Models;

namespace Demo.Implementations.Tests
{
    [TestClass()]
    public class ProductManagerTests
    {
        [TestMethod()]
        public void GetSaleItemsTest()
        {
            Mock<IProductStore> mockedStore = new Mock<IProductStore>();

            DateTime orderDate = new DateTime(2017, 2, 8);

            mockedStore.Setup(x => x.GetList()).Returns(new List<Product> { new Product {
                                                                                Price = 10,
                                                                                AddedOn = new DateTime(2017, 2, 6),
                                                                                Orders = new List<Order>() { new Order {
                                                                                                            CreatedOn = orderDate
                                                } } } });

            ProductManager managerUnderTest = new ProductManager(mockedStore.Object);
            IEnumerable<Product> saleItems = managerUnderTest.GetSaleItems((decimal).01, 1);

            int daysBelow = (int)(DateTime.Today.Date.Subtract(orderDate).TotalDays + 1);

            Assert.AreEqual(1, saleItems.Count());

            Assert.AreEqual((decimal)(10 - .01 * 10 * daysBelow), saleItems.First().Price);
        }
    }
}