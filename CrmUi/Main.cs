using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProducts = new Catalog<Product>(db.Products);
            catalogProducts.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSellers = new Catalog<Seller>(db.Sellers);
            catalogSellers.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomers = new Catalog<Customer>(db.Customers);
            catalogCustomers.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogChecks = new Catalog<Check>(db.Checks);
            catalogChecks.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var customerAddForm = new CustomerAddForm();
            if (customerAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerAddForm.Customer);
                db.SaveChanges();
            }
        }
        private void sellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sellerAddForm = new SellerAddForm();
            if (sellerAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(sellerAddForm.Seller);
                db.SaveChanges();
            }
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productAddForm = new ProductAddForm();
            if (productAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(productAddForm.Product);
                db.SaveChanges();
            }

        }
    }

}
