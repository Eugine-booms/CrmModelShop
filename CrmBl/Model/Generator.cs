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
        }
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
            return resultList;
        }
        public List<Seller> GenerateNewSellers(int count)
        {
            var resultList = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    Name = GetRndText(),
                    SellerId = i
                };
                resultList.Add(seller);
            }
            return resultList;
        }
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
            return resultList;
        }
        private static string GetRndText()
        {
            return Guid.NewGuid().ToString().Substring(5, 10);
        }

    }
}
