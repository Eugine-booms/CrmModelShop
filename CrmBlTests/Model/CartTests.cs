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
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //arrange 
            var customer = new Customer() { Name = "testuser" };
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
                ProductId=3
            };
            var expectedResult = new List<Product>()
            {
                product1, product1, product2, product3, product3, product3
            };
            var cart = new Cart(customer);
            //act
            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);
            cart.Add(product3); 
            cart.Add(product3);
            List<Product> cartResult = cart.GetAllProduct();

            //assert
            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }

        //[TestMethod()]
        //public void AddTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEnumeratorTest()
        //{
        //    Assert.Fail();
        //}
    }
}