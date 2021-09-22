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



        public ShopComputerModel(int sellersCount = 20, int productCount = 1000, int customersCount = 10)
        {
            this.Generator = new Generator();
            this.Sellers = new Queue<Seller>();
            this.CashDesks = new List<CashDesk>();
            Generator.GenerateNewProducts(productCount);
            Generator.GenerateNewSellers(sellersCount);
        }

        private void SeatsSellersAtCashDesks(int count)
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

        public void Start(int cashDeskCount = 3, int serviceTime = 60)
        {
            SeatsSellersAtCashDesks(cashDeskCount);
            IsWorking = true;
            Task.Run(() => GenerateShoppingCarts(5));
            Task.Run(() => DistributesCustomerToCashDesk(Carts));
            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, serviceTime)));
            foreach (var task in cashDeskTasks)
            {
                task.Start();
            }
        }
        public void Stop()
        {
            IsWorking = false;
        }
        private decimal CashDeskWork(CashDesk cashDesk, int serviceTime)
        {
            if (cashDesk.CountCustomer > 0)
            {
                Thread.Sleep(serviceTime * 100);
                return cashDesk.SingleCustomerService(cashDesk.Dequeue(), cashDesk).Summ;
            }
            return 0;
        }

        private void DistributesCustomerToCashDesk(Queue<Cart> carts)
        {
            var goneBuyer = new List<Cart>();
            while (IsWorking)
            {
                    while (carts != null&&carts.Count > 0)
                    {
                        var cashDesk = GetMinCounterCashDesk();
                        var notSellCart = cashDesk.Enqueue(carts.Dequeue());
                        if (notSellCart != null)
                        {
                            goneBuyer.Add(notSellCart);
                        }
                    }
            }
            GoneBuyers= goneBuyer;
        }

        private CashDesk GetMinCounterCashDesk()
        {
            return CashDesks.FirstOrDefault(cd => cd.CountCustomer == CashDesks.Min(c => c.CountCustomer));
        }
        private void GenerateShoppingCarts(int customersCameInDelay)
        {
            while (IsWorking)
            {
                Thread.Sleep(customersCameInDelay * 100);
                Carts = FormationShoppingCarts(1, 10, 30);
            }
        }

        private Queue<Cart> FormationShoppingCarts(int incomingBuyersCount = 10, int minProductCount = 10, int maxProductCount = 30)
        {
            Generator.GenerateNewCustomers(10);
            var incomingBuyers = Generator.GetCustomers(incomingBuyersCount);
            //var carts = FormationShoppingCarts(incomingBuyers, 5);
            var carts = new Queue<Cart>();
            foreach (var customer in incomingBuyers)
            {
                var cart = new Cart(customer);
                foreach (var product in Generator.GetProducts(minProductCount, maxProductCount))
                {

                    Thread.Sleep(customer.ProductFindTime * 1000);
                    cart.Add(product);
                }
                carts.Enqueue(cart);
            }
            return carts;
        }
    }
}
