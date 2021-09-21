using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void GoneBuyersCount0()
        {
            var model = new ShopComputerModel();
            var generator = model.Generator;


            model.Start(cashDeskCount:3, incomingBuyersCount:10);


            Assert.AreEqual(0, model.GoneBuyers.Count);
        }
        [TestMethod()]
        public void GoneBuyersCount1()
        {
            var model = new ShopComputerModel(sellersCount:20,productCount:1000, customersCount:31);
            var generator = model.Generator;


            model.Start(cashDeskCount: 3, incomingBuyersCount: 31);


            Assert.AreEqual(1, model.GoneBuyers.Count);
        }
        [TestMethod()]
        public void GoneBuyersCashSumm()
        {
            var model = new ShopComputerModel(sellersCount: 20, productCount: 1000, customersCount: 30);
            decimal expectedSumm = 0;
            var Summ= model.Start(cashDeskCount: 3, incomingBuyersCount: 30).Sum();
            expectedSumm=model.CashDesks.SelectMany(x => x.Checks).Sum(s=>s.Summ);

            Assert.AreEqual(expectedSumm, Summ);
        }
    }
}