using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void GoneBuyersCount0()
        {
            var model = new ShopComputerModel();
            model.Start(cashDeskCount:3, 1);
            Thread.Sleep(5000000);
            model.Stop();
           
        }
        //[TestMethod()]
        //public void GoneBuyersCount1()
        //{
        //    var model = new ShopComputerModel(sellersCount:20,productCount:1000, customersCount:31);
        //    var generator = model.Generator;


        //    model.Start(cashDeskCount: 3, 60);


        //    Assert.AreEqual(1, model.GoneBuyers.Count);
        //}
        //[TestMethod()]
        //public void GoneBuyersCashSumm()
        //{
        //    var model = new ShopComputerModel(sellersCount: 20, productCount: 1000, customersCount: 30);
        //    decimal expectedSumm = 0;
        //    //var Summ= model.Start(cashDeskCount: 3).Sum();
        //    expectedSumm=model.CashDesks.SelectMany(x => x.Checks).Sum(s=>s.Summ);

        //    Assert.AreEqual(expectedSumm, Summ);
        //}
    }
}