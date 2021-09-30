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
        private CrmContext db;
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> QueueCarts { get; set; }
        private int maxQueueLenght = 10;
        public event EventHandler<Check> ChekOut;
        public event EventHandler<int> QueueCartsChanged;
        public int ExitCustomerCount { get; set; }
        public bool IsModel { get; set; } = true;
       // public List<Check> Checks { get; private set; }
        public int CountCustomer => QueueCarts.Count;

        public int GetMaxQueueLenght()
        {
            return maxQueueLenght;
        }

        public void SetMaxQueueLenght(int value = 10)
        {
            maxQueueLenght = value;
        }

        public CashDesk( int number, Seller seller, int maxQueueLenght, CrmContext db)
        {
            this.db = db ?? new CrmContext();
            Number = number;
            Seller = seller ?? throw new ArgumentNullException(nameof(seller));
            QueueCarts = new Queue<Cart>();
     //       Checks = new List<Check>();
            this.maxQueueLenght = maxQueueLenght;
        }
        public Cart Enqueue(Cart cart)
        {
            if (QueueCarts.Count < GetMaxQueueLenght())
            {
                QueueCarts.Enqueue(cart);
                QueueCartsChanged?.Invoke(this, QueueCarts.Count);
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
            while (isWork)
            {
                var nextCart = Dequeue();
                if (nextCart == null) break;
                Summ += SingleCustomerService(nextCart).Summ;
            }
            return Summ;
        }
        public Cart Dequeue()
        {
            if (QueueCarts.Count > 0)
            {
                QueueCartsChanged?.Invoke(this, QueueCarts.Count - 1);
                return QueueCarts.Dequeue();
            }
            return null;
        }
        private Sell ChangesNumberItems(Product product)
        {
            if (product.Count > 0)
            {
                var sell = new Sell
                {
                    Product = product
                };
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
                if (sell != null)
                {
                    if (IsModel)
                    {
                        sell.SellId = i++;
                        sell.CheckId = check.CheckId;
                    }
                    sell.Check = check;
                    check.Summ += product.Price;
                    sells.Add(sell);
                }
            }

           SaveDbSels(sells);
            return sells;
        }
        private void SaveDbSels(List<Sell> data)
        {
            if (!IsModel)
            {

                db.Sells.AddRange(data);
               // db.SaveChanges();
            }
        }
        private void SaveDbChek(Check chek)
        {
            if (!IsModel)
            {
                db.Checks.Add(chek);
                db.SaveChanges();
            }
        }
        public Check SingleCustomerService(Cart cart)
        {
            var check = new Check();
            if (cart != null)
            {
                
                check.Created = DateTime.Now;
                check.Customer = cart.Customer;
                check.Seller = Seller;
               
                var sells = Sell(cart, check);
                if (IsModel)
                {
                    check.CustomerId = cart.Customer.CustomerId;
                    check.SellerId = Seller.SellerId;
                    check.Sells = sells;
                }

            }
            if (IsModel)
            {
                check.CheckId = cart.Customer.CustomerId + this.Number * 100000;
            }
            SaveDbChek(check);
            ChekOut?.Invoke(this, check);
            return check;
        }
        public override string ToString()
        {
            return $"Касса № {Number}";
        }
    }
}
