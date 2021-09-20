using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void DequeueTest()
        {
            //arrange 
            var seller = new Seller() { Name = "boomsa" };
            var cashDesk = new CashDesk(1, seller);
            var customer1 = new Customer() { Name = "testuser1" };
            var customer2 = new Customer() { Name = "testuser2" };
            var cart1 = new Cart(customer1);
            var cart2 = new Cart(customer2);

            var product1 = new Product()
            {
                Name = "Pr1",
                Price = 100,
                Count = 10,
                ProductId = 1
            };
            var product2 = new Product()
            {
                Name = "Pr2",
                Price = 50,
                Count = 11,
                ProductId = 2
            };
            var product3 = new Product()
            {
                Name = "Pr3",
                Price = 75,
                Count = 12,
                ProductId = 3
            };
            cart1.Add(product1);
            cart2.Add(product1);
            cart1.Add(product2);
            cart2.Add(product3);
            cart1.Add(product3);
            cart2.Add(product3);
            var expectedCart1 = cart1.GetAllProduct();
            var expectedCart2 = cart2.GetAllProduct();
            //act
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);
            var dequeueCart1 = cashDesk.Dequeue().GetAllProduct();
            var dequeueCart2 = cashDesk.Dequeue().GetAllProduct();
            //assert


            for (int i = 0; i < expectedCart1.Count; i++)
            {
                Assert.AreEqual(expectedCart1[i], dequeueCart1[i]);
            }
            for (int i = 0; i < expectedCart2.Count; i++)
            {
                Assert.AreEqual(expectedCart2[i], dequeueCart2[i]);
            }
        }

        [TestMethod()]
        public void CheckoutTest()
        {

            var seller = new Seller() { Name = "boomsa" , SellerId = 1};
            var customer1 = new Customer() { Name = "testuser1", CustomerId = 1 };
            var cart1 = new Cart(customer1);
            var cashDesk = new CashDesk(1, seller);
            var product1 = new Product()
            {
                Name = "Pr1",
                Price = 100,
                Count = 10,
                ProductId = 1
            };
            var product2 = new Product()
            {
                Name = "Pr2",
                Price = 50,
                Count = 11,
                ProductId = 2
            };
            var expectepSaleList = new List<Product>();
            cart1.Add(product1);
            expectepSaleList.Add(product1);
            cart1.Add(product1);
            expectepSaleList.Add(product1);
            cart1.Add(product2);
            expectepSaleList.Add(product2);
            //act
            var ExpectepSaleList = new List<Product>();
            var check = cashDesk.Checkout(cart1);
            //Assert
            Assert.AreEqual(0, check.CheckId);
            Assert.AreEqual("testuser1", check.Customer.Name);
            Assert.AreEqual(1, check.CustomerId);
            Assert.AreEqual("boomsa", check.Seller.Name);
            Assert.AreEqual(1, check.SellerId);
            var sells = check.Sells.ToList();
            for (int i = 0; i < expectepSaleList.Count; i++)
            {
                Assert.AreEqual(expectepSaleList[i], sells[i].Product);
            }
            Assert.AreEqual(8, product1.Count);
            Assert.AreEqual(10, product2.Count);
            Assert.AreEqual(250, check.Summ);
        }

        [TestMethod()]
        public void WorkTest()
        {
            var seller = new Seller() { Name = "boomsa" };
            var cashDesk = new CashDesk(1, seller);
            var customer1 = new Customer() { Name = "testuser1" };
            var customer2 = new Customer() { Name = "testuser2" };
            var cart1 = new Cart(customer1);
            var cart2 = new Cart(customer2);

            var product1 = new Product()
            {
                Name = "Pr1",
                Price = 100,
                Count = 10,
                ProductId = 1
            };
            var product2 = new Product()
            {
                Name = "Pr2",
                Price = 50,
                Count = 11,
                ProductId = 2
            };
            var product3 = new Product()
            {
                Name = "Pr3",
                Price = 75,
                Count = 12,
                ProductId = 3
            };
            cart1.Add(product1);
            cart2.Add(product1);
            cart1.Add(product2);
            cart2.Add(product3);
            cart1.Add(product3);
            cart2.Add(product3);
            decimal expectedSumm = 100 + 100 + 50 + 75 + 75 + 75;
            //act
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);
            var summ =cashDesk.Work();
            Assert.AreEqual(expectedSumm, summ);
        }
    }
}