using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Generator
    {
        Random rnd = new Random();
        //  public List<Cart> Carts{ get; set;  }
        //  public List<Sell> Sells { get; set; }
        //  public List<Check> Checks { get; set; }
      //  public List<CashDesk> CashDesks { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
       
        public List<Seller> Sellers { get; set; }


        public List<CashDesk> GetNewCashDesk(int count, int vaxQueueLenght, List<Seller> sellers=null)
        {

            if (sellers==null)
            {
                sellers = GetNewSellers(count);
            }
            if (sellers.Count<count)
            {
                throw new ArgumentException(nameof(sellers.Count), "Мало продавцов");
            }
            var resultList = new List<CashDesk>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var cashDesk = new CashDesk(i, sellers[i])
                {
                    Number = i,
                    ExitCustomerCount = 0,
                    MaxQueueLenght = vaxQueueLenght
                };
                resultList.Add(cashDesk);
            }
            return resultList;
        }
        public List<Customer> GetNewCustomers(int count)
        {
            var resultList = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var customer = new Customer()
                {
                    Name = name,
                    CustomerId = Customers.Count
                };
                resultList.Add(customer);
            }
            return resultList;
        }
        public List<Seller> GetNewSellers(int count)
        {
            var resultList = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var seller = new Seller()
                {
                    Name = GetRndText(),
                    SellerId = Sellers.Count
                };
                resultList.Add(seller);
            }
            return resultList;
        }
      
        public List<Product> GetNewProducts(int count)
        {
            var resultList = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var name = GetRndText();
                var product = new Product()
                {
                    Name = GetRndText(),
                    ProductId = Products.Count,
                    Count = rnd.Next(10, 1000),
                    Price = (decimal)(rnd.Next(5, 100000) + rnd.NextDouble())
                };
                resultList.Add(product);
            }
            return resultList;
        }
        public List<Cart> GetNewCart(int count, int productCount)
        {
            var resultList = new List<Cart>();
            var customers = GetNewCustomers(count);
            for (int i = 0; i < count; i++)
            {
                var cart = new Cart(customers[i]);
                var products = GetNewProducts(productCount);
                foreach (var product in products)
                {
                    cart.Add(product);
                }
                resultList.Add(cart);
            }
            return resultList;
        }
        public List<Cart> GetNewCart(int count, List<Product> products)
        {
            var resultList = new List<Cart>();
            var customers = GetNewCustomers(count);
            for (int i = 0; i < count; i++)
            {
                var cart = new Cart(customers[i]);
                foreach (var product in products)
                {
                    cart.Add(product);
                }
                resultList.Add(cart);
            }
            return resultList;
        }


        private static string GetRndText()
        {
            return Guid.NewGuid().ToString().Substring(5, 10);
        }



    }
}
