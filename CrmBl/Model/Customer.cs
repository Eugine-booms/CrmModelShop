using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int ProductFindTime { get; set; }
        public virtual ICollection<Check> Checks { get; set; }
        public Customer()
        {
        }
        public override string ToString()
        {
            return $"{CustomerId}.{Name}"; 
        }
    }
}
