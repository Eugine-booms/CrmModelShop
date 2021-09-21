using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class ShopComputerModel
    {
        public Generator Generator { get; }
        public List<CashDesk> CashDesks { get; set; }

        public List<Cart> GoneBuyers { get; private set; }
        public Queue<Seller> Sellers { get; set; }



        public ShopComputerModel(int sellersCount=20, int productCount=1000,  int customersCount=10)
        {
            this.Generator = new Generator();
            this.Sellers = new Queue<Seller>();
            this.CashDesks = new List<CashDesk>();
            Generator.GenerateNewCustomers(customersCount);
            Generator.GenerateNewSellers(sellersCount);
            Generator.GenerateNewProducts(productCount);
            
            
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

        public List<decimal> Start (int cashDeskCount = 3, int incomingBuyersCount=10)
        {
            
            SeatsSellersAtCashDesks(cashDeskCount);
            var incomingBuyers = Generator.GetCustomers(incomingBuyersCount);
            var carts = FormationShoppingCarts(incomingBuyers);
            GoneBuyers= DistributesCustomerToCashDesk(carts);
            var summList=StartWork();
            return summList;
        }

        private List<decimal> StartWork()
        {
            var summList = new List<decimal>();
            foreach (var cashDesk in CashDesks)
            {
                var summ = cashDesk.ModelWorkCashDesk();
                summList.Add(summ);
            }
            return summList;
        }

        private List<Cart> DistributesCustomerToCashDesk(Queue<Cart> carts)
        {
            var goneBuyer = new List<Cart>();
            while(carts.Count>0)
            {
                var cashDesk = GetMinCounterCashDesk();
                var notSellCart = cashDesk.Enqueue(carts.Dequeue());
                if (notSellCart!=null)
                {
                    goneBuyer.Add(notSellCart);
                }
            }
            return goneBuyer;
        }

        private CashDesk GetMinCounterCashDesk()
        {
            return CashDesks.FirstOrDefault(cd => cd.CountCustomer == CashDesks.Min(c => c.CountCustomer));
        }

        private Queue<Cart> FormationShoppingCarts(List<Customer> customers)
        {
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var product in Generator.GetProducts(10, 30))
                {
                    cart.Add(product);
                }
                carts.Enqueue(cart);
            }
            return carts;
        }
    }
}
