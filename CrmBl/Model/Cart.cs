using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model
{
    public class Cart : IEnumerable
    {
        public Cart(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Products = new Dictionary<Product, int>();
        }

        public Customer Customer { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public void Add(Product product)
        {
            
            if (Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator GetEnumerator()
        {
            foreach (Product product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }
        public IEnumerable GetProduct()
        {
            foreach (var product in Products)
            {
                yield return product;
            }
        }
        //public Product this[int i]
        //{
        //    get
        //    {
        //        return Products[i];
        //    }
        //}
        public List<Product> GetAllProduct()
        {
            var result = new List<Product>();
            foreach (Product i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
