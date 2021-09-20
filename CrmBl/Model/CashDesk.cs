using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class CashDesk
    {
        readonly CrmContext db = new CrmContext();
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> QueueCarts { get; set; }
        public int MaxQueueLenght { get; set; } = 10;
        public int ExitCustomerCount { get; set; }
        public bool IsModel { get; set; } = true;

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller ?? throw new ArgumentNullException(nameof(seller));
            QueueCarts = new Queue<Cart>();
        }
        public Cart Enqueue (Cart cart)
        {
            if (QueueCarts.Count<= MaxQueueLenght)
            {
                QueueCarts.Enqueue(cart);
                return null;
            }
            else
            {
                ExitCustomerCount++;
                return cart;
            }
        }
        public decimal Work()
        {
            decimal Summ = 0;
            while (true)
            {
                var nextCart = Dequeue();
                if (nextCart == null) break;
                var check = Checkout(nextCart);
                Summ += check.Summ;
            }
            return Summ;
        }

        public Cart Dequeue()
        {
            if (QueueCarts.Count>0)
            {
                return QueueCarts.Dequeue();
            }
            return null;
        }
        public Check Checkout (Cart cart)
        {
            var check = new Check();
            if (cart !=null)
            {
                check.Created = DateTime.Now;
                check.CustomerId = cart.Customer.CustomerId;
                check.Customer = cart.Customer;
                check.SellerId = Seller.SellerId;
                check.Seller = Seller;
                var sells = Seled(cart, check);
                check.Sells = sells;
            }
            if(IsModel)
            {
                check.CheckId = 0;
            }
            SaveDb(new List<Check>() { check });
            return check;
        }
        private Sell CanSalle(Product product)
        {
            
            if (product.Count > 0)
            if (product.Count>0)
            {
                var sell = new Sell();
                sell.Product = product;
                product.Count--;
                sell.ProductId = product.ProductId;
                return sell;
            }
            return null;
        }
        private List<Sell> Seled(Cart cart, Check check)
        public List<Sell> Selled(Cart cart, Check check)
        {
            List<Sell> sells = new List<Sell>();
            var products = cart.GetAllProduct();
            int i = 0;
            foreach (var product in products)
            {
                var sell = CanSalle(product);
                if (sell != null)
                if (sell!=null)
                {
                    if (IsModel)
                    {
                        sell.SellId = i++;
                    }
                    sell.Check = check;
                    sell.CheckId = check.CheckId;
                    check.Summ += product.Price;
                    sells.Add(sell);
                }
            }
            SaveDb(sells);
            return sells;
        }
        private void SaveDb<T>(List<T> data) where T : class
        private void SaveDb <T>(List<T> data) where T:class
        {
            if (!IsModel)
            {
                db.Set(typeof(T)).AddRange(data);
                db.SaveChangesAsync();
            }
        }
        public Check Checkout (Cart cart)
        {
            var check = new Check();
            if (cart !=null)
            {
                check.Created = DateTime.Now;
                check.CustomerId = cart.Customer.CustomerId;
                check.Customer = cart.Customer;
                check.SellerId = Seller.SellerId;
                check.Seller = Seller;
                var sells = Selled(cart, check);
                check.Sells = sells;
            }
            if(IsModel)
            {
                check.CheckId = 0;
            }
            SaveDb(new List<Check>() { check });
            return check;
        }


    }
}
