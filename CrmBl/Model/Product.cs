﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Product
    {
        public Product()
        {
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return Name + " " + Price;
        }
    }
}