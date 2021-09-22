using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Generator
    {
        public Random rnd = new Random();

        public Generator()
        {
            //Products = new List<Product>();
            //Customers = new List<Customer>();
            //Sellers = new List<Seller>();
        }

        //  public List<Sell> Sells { get; set; }
        //  public List<Check> Checks { get; set; }
      //  public List<Product> Products { get; set; }
      //  public List<Customer> Customers { get; set; }
      //  public List<Seller> Sellers { get; set; }
        public List<Customer> GenerateNewCustomers(int count, int productMaxFindTime)
        {
            var resultList = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var customer = new Customer()
                {
                    Name = name,
                    CustomerId = i,
                    ProductFindTime = rnd.Next(0, productMaxFindTime)
                };
                resultList.Add(customer);
            }
          //  Customers.AddRange(resultList);
            return resultList;
        }
        //public List<Customer> GetCustomers(int count)
        //{
        //    if (Customers==null)
        //    {
        //        GenerateNewCustomers(count);
        //    }
        //    var result = new List<Customer>();
        //    if (Customers.Count>=count)
        //    {
        //        result= Customers.Take(count).ToList();
        //        Customers.RemoveRange(0,count);
        //    }
        //    else 
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(Customers), "Пришло больше покупателей чем сгенерировано");
        //    }
        //    return result;
        //}

        public List<Seller> GenerateNewSellers(int count)
        {
            var resultList = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var seller = new Seller()
                {
                    Name = GetRndText(),
                    SellerId = i
                };
                resultList.Add(seller);
            }
        //    Sellers = resultList;
            return resultList;
        }
        //public List<Product> GetProducts(int min, int max)
        //{
        //    var result = new List<Product>();
        //    var count = rnd.Next(min, max);
        //    if (Products.Count > count)
        //    {
        //        result = Products.Take(count).ToList();
        //        Products.RemoveRange(0, count);
        //    }
        //    else
        //    {
        //        result = Products.Take(Products.Count).ToList();
        //        Products.RemoveRange(0, Products.Count);
        //    }
        //    return result;
        //}
        public List<Product> GenerateNewProducts(int count)
        {
            var resultList = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var product = new Product()
                {
                    Name = GetRndText(),
                    ProductId = i,
                    Count = rnd.Next(10, 1000),
                    Price = (decimal)(rnd.Next(5, 500) + rnd.NextDouble())
                };
                resultList.Add(product);
            }
          //  Products = resultList;
            return resultList;
        }
        //public List<Product> GetRandomProducts(int min, int max)
        //{
        //    var result = new List<Product>();
        //    var count = rnd.Next(min, max);
        //    for (int i = 0; i < count; i++)
        //    {
        //        result.Add(Products[rnd.Next(0, Products.Count - 1)]);
        //    }
        //    return result;
        //}
        private static string GetRndText()
        {
            return Guid.NewGuid().ToString().Substring(5, 10);
        }

    }
}
