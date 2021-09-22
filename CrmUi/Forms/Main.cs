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
using CrmUi.Forms;

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
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProducts = new Catalog<Product>(db, db.Products);
            catalogProducts.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSellers = new Catalog<Seller>(db, db.Sellers);
            catalogSellers.Show();
        }

        private  void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomers = new Catalog<Customer>(db, db.Customers);
            catalogCustomers.Show();
            //OpenDialogAsync(sender, e);
        }
       
        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogChecks = new Catalog<Check>(db, db.Checks);
            catalogChecks.Show();
        }
        private void CustomerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var customerAddForm = new CustomerAddForm();
            if (customerAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerAddForm.Customer);
                db.SaveChanges();
            }
        }
        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sellerAddForm = new SellerAddForm();
            if (sellerAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(sellerAddForm.Seller);
                db.SaveChanges();
            }
        }
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productAddForm = new ProductAddForm();
            if (productAddForm.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(productAddForm.Product);
                db.SaveChanges();
            }

        }

        private void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modForm = new ModForm();
            modForm.Show();

        }

        //public async Task OpenDialogAsync(object sender, EventArgs e)
        //{
        //    await Task.Run(() => OpenDialog(sender, e));
        //}

        //private void OpenDialog(object sender, EventArgs e)
        //{
        //    var catalogCustomers = new Catalog<Customer>(db.Customers);
        //    catalogCustomers.Show();
        //}
    }

}
