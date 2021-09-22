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
        private int maxQueueLenght = 10;
        public event EventHandler<Check> ChekOut;
        public int ExitCustomerCount { get; set; }
        public bool IsModel { get; set; } = true;
        public List<Check> Checks { get; private set; }
        public int CountCustomer => QueueCarts.Count;
        public int GetMaxQueueLenght()
        {
            return maxQueueLenght;
        }

        public void SetMaxQueueLenght(int value)
        {
            maxQueueLenght = value;
        }

        public CashDesk(int number, Seller seller, int maxQueueLenght)
        {
            Number = number;
            Seller = seller ?? throw new ArgumentNullException(nameof(seller));
            QueueCarts = new Queue<Cart>();
            Checks = new List<Check>();
            this.maxQueueLenght = maxQueueLenght;
        }
        public Cart Enqueue (Cart cart)
        {
            if (QueueCarts.Count< GetMaxQueueLenght())
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
        public decimal ModelWorkCashDesk(bool isWork, CashDesk cd)
        {
            decimal Summ = 0;
            int checkId = 0;
            while (isWork)
            {
                var nextCart = Dequeue();
                if (nextCart == null) break;
                Summ += SingleCustomerService(nextCart, cd).Summ;
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
        private Sell ChangesNumberItems(Product product)
        {
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
        private List<Sell> Sell(Cart cart, Check check)
        {
            List<Sell> sells = new List<Sell>();
            var products = cart.GetAllProduct();
            int i = 0;
            foreach (var product in products)
            {
                var sell = ChangesNumberItems(product);
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
        private void SaveDb <T>(List<T> data) where T:class
        {
            if (!IsModel)
            {
                db.Set(typeof(T)).AddRange(data);
                db.SaveChangesAsync();
            }
        }
        public Check SingleCustomerService (Cart cart, CashDesk cashDesk)
        {
            var check = new Check();
            if (cart !=null)
            {
                check.Created = DateTime.Now;
                check.CustomerId = cart.Customer.CustomerId;
                check.Customer = cart.Customer;
                check.SellerId = Seller.SellerId;
                check.Seller = Seller;
                var sells = Sell(cart, check);
                check.Sells = sells;
            }
            if(IsModel)
            {
                check.CheckId = cart.Customer.CustomerId+cashDesk.Number*100000;
            }
            SaveDb(new List<Check>() { check });
            ChekOut?.Invoke(this, check);
            Checks.Add(check);
            return check;
        }

    }
}
