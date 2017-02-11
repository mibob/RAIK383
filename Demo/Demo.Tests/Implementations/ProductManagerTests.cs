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

            mockedStore.Setup(x => x.GetList()).Returns(new List<Product> { new Product {
                                                                                Price = 10,
                                                                                AddedOn = new DateTime(2017, 2, 6),
                                                                                Orders = new List<Order>() { new Order {
                                                                                                            CreatedOn = new DateTime(2017, 2, 8)
                                                } } } });

            ProductManager managerUnderTest = new ProductManager(mockedStore.Object);
            IEnumerable<Product> saleItems = managerUnderTest.GetSaleItems(1, 1);

            Assert.AreEqual(1, saleItems.Count());

            //TODO: fix this to not use hard-coded number, but formula depending on days past
            //Assert.AreEqual((decimal)9.8, saleItems.First().Price);
        }
    }
}