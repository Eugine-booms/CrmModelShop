﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Check
    {
        public int CheckId { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime Created { get; set; }
        public decimal Summ { get; set; } = 0;
        public virtual ICollection<Sell> Sells { get; set; }
       
        public Check()
        {
        }
        public override string ToString()
        {
            return $"№{CheckId} от {Created.ToString("G")}";
        }
    }
}
