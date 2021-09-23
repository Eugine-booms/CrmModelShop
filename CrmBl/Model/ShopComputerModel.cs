using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        ConcurrentBag<Task> Tasks = new ConcurrentBag<Task>();

        public Generator Generator { get; }
        public List<CashDesk> CashDesks { get; set; }
        public Queue<Seller> Sellers { get; set; }
        public Queue<Cart> Carts { get; set; }
        bool IsWorking = false;
        public event EventHandler<int> CartsQueueChanged;
        public event EventHandler<int> BuyersGone;
        public int CustomerSpeedDelay { get; set; }
        public int CashDeskSpeedDelay { get; set; }
        public int ProductMaxFindTime { get; set; }
        public int CashDeskCount { get; set; }


        public ShopComputerModel()
        {
            this.Generator = new Generator();
            this.Sellers = new Queue<Seller>();
            this.CashDesks = new List<CashDesk>();
            Carts = new Queue<Cart>();
            AddSellersToModel(20);
        }
        public void GenerateCashDesk(int count, int maxQueueLenght = 10)
        {
            for (int i = 0; i < count; i++)
            {
                CashDesks.Add(new CashDesk(i + 1, Sellers.Dequeue(), maxQueueLenght));
            }
        }
        public void AddSellersToModel(int count)
        {
            var sellers = Generator.GenerateNewSellers(count);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

        }
        public void Start()
        {
            IsWorking = true;
            var token = tokenSource.Token;

            Tasks.Add(Task.Run(() => GenerateShoppingCarts(), token));
            Thread.Sleep(100);
            Tasks.Add(Task.Run(() => DistributesCustomerToCashDesk(Carts), token));
            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c), token));
            foreach (var task in cashDeskTasks)
            {
                Tasks.Add(task);
                task.Start();
            }
        }
        public async void Stop()
        {
            IsWorking = false;
            foreach (var task in Tasks)
            {
                tokenSource.Cancel();
                try
                {
                    await Task.WhenAll(Tasks.ToArray());
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"\n{nameof(OperationCanceledException)} thrown\n");
                }
                finally
                {
                    tokenSource.Dispose();
                }
            }

        }
        private void CashDeskWork(CashDesk cashDesk)
        {
            while (IsWorking)
            {
                if (cashDesk.CountCustomer > 0)
                {
                    Thread.Sleep(CashDeskSpeedDelay);
                    cashDesk.SingleCustomerService(cashDesk.Dequeue(), cashDesk);
                }
            }
        }
        private void DistributesCustomerToCashDesk(Queue<Cart> carts)
        {
            while (IsWorking)
            {
                while (carts != null && carts.Count > 0)
                {
                    var cashDesk = GetMinCounterCashDesk();
                    var notSellCart = cashDesk.Enqueue(carts.Dequeue());
                    if (notSellCart != null)
                    {
                        cashDesk.ExitCustomerCount++;
                    }
                }
            }
        }
        private CashDesk GetMinCounterCashDesk()
        {
            return CashDesks.FirstOrDefault(cd => cd.CountCustomer == CashDesks.Min(c => c.CountCustomer));
        }
        private void GenerateShoppingCarts()
        {
            while (IsWorking)
            {
                Carts.Enqueue(FormationShoppingCarts(10, 30));
                CartsQueueChanged?.Invoke(this, Carts.Count);
                Thread.Sleep(CustomerSpeedDelay);
            }
        }
        private Cart FormationShoppingCarts(int minProductCount, int maxProductCount)
        {
            var customer = (Customer)Generator.GenerateNewCustomers(1, ProductMaxFindTime).First();
            var cart = new Cart(customer);
            var products = Generator.GenerateNewProducts(30);
            var rnd = Generator.rnd.Next(minProductCount, maxProductCount);
            foreach (var product in products.Take(rnd))
            {
                // Thread.Sleep(customer.ProductFindTime * 1);
                cart.Add(product);
            }
            return cart;
        }
    }
}
