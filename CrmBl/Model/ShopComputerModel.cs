using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        public Generator Generator { get; }
        public List<CashDesk> CashDesks { get; set; }
        public List<Cart> GoneBuyers { get; private set; }
        public Queue<Seller> Sellers { get; set; }
        public Queue<Cart> Carts { get; set; }
        bool IsWorking = false;
        public event EventHandler<int> CartsQueueChanged;
        public event EventHandler<int> BuyersGone;
        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;
        public int CashDeskCount { get; set; }


        public ShopComputerModel(int sellersCount = 20, int productCount = 1000, int customersCount = 10)
        {
            this.Generator = new Generator();
            this.Sellers = new Queue<Seller>();
            this.CashDesks = new List<CashDesk>();
            Carts = new Queue<Cart>();
            Generator.GenerateNewProducts(productCount);
            Generator.GenerateNewSellers(sellersCount);
        }

        public void SeatsSellersAtCashDesks(int count)
        {
            foreach (var seller in Generator.Sellers)
            {
                Sellers.Enqueue(seller);
            }
            for (int i = 0; i < count; i++)
            {
                CashDesks.Add(new CashDesk(i + 1, Sellers.Dequeue(), 10));
            }
        }

        public void Start(int  CustomerComeInDelay = 1)
        {
            var rnd = new Random();
            var serviceTimeRandom = rnd.NextDouble() * CashDeskSpeed*100;
            SeatsSellersAtCashDesks(CashDeskCount);
            IsWorking = true;
            var generate =Task.Run(()=>GenerateShoppingCarts(CustomerSpeed));
            Thread.Sleep(500);
            var Distribut = Task.Run(() => DistributesCustomerToCashDesk(Carts));
            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, (int)(serviceTimeRandom*10))));
            foreach (var task in cashDeskTasks)
            {
                task.Start();
            }
        }
        public void Stop()
        {
            IsWorking = false;
        }
        private void CashDeskWork(CashDesk cashDesk, int serviceTime)
        {
            while (true)
            {
                if (cashDesk.CountCustomer > 0)
                {
                    Thread.Sleep(serviceTime);
                    cashDesk.SingleCustomerService(cashDesk.Dequeue(), cashDesk);
                }
            }
        }

        private void DistributesCustomerToCashDesk(Queue<Cart> carts)
        {
            var goneBuyer = new List<Cart>();
            while (true)
            {
                while (carts != null && carts.Count > 0)
                {
                    var cashDesk = GetMinCounterCashDesk();
                    var notSellCart = cashDesk.Enqueue(carts.Dequeue());
                    if (notSellCart != null)
                    {
                        goneBuyer.Add(notSellCart);
                        BuyersGone?.Invoke(this, goneBuyer.Count);
                    }
                }
            }
            GoneBuyers = goneBuyer;
        }

        private CashDesk GetMinCounterCashDesk()
        {
            return CashDesks.FirstOrDefault(cd => cd.CountCustomer == CashDesks.Min(c => c.CountCustomer));
        }
        private void GenerateShoppingCarts(int customersCameInDelay)
        {
            while (IsWorking)
            {

                Carts.Enqueue(FormationShoppingCarts(10, 30));
                CartsQueueChanged?.Invoke(this, Carts.Count);
                Thread.Sleep(customersCameInDelay);
            }
        }

        private Cart FormationShoppingCarts(int minProductCount = 10, int maxProductCount = 30)
        {
            Generator.GenerateNewCustomers(1);
            var customer = (Customer)Generator.GetCustomers(1).First();
            var cart = new Cart(customer);
            foreach (var product in Generator.GetProducts(minProductCount, maxProductCount))
            {
                Thread.Sleep(customer.ProductFindTime * 1);
                cart.Add(product);
            }

            return cart;
        }
    }
}
