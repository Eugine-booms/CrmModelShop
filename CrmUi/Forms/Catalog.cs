using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public Catalog(CrmContext db, DbSet<T> set)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
            Show();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var type = typeof(T);
            if (type == typeof(Product))
            {

            }
            else if (type == typeof(Seller))
            {

            }
            else if (type == typeof(Customer))
            {

            }
            else if (type == typeof(Check))
            {

            }

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var productChange = new ProductAddForm(product);
                    if (productChange.ShowDialog() == DialogResult.OK)
                    {
                        product = productChange.Product;
                        db.SaveChanges();
                        dataGridView.Update();
                        dataGridView.Show();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var customerChangeForm = new CustomerAddForm(customer);
                    if (customerChangeForm.ShowDialog() == DialogResult.OK)
                    {
                        customer = customerChangeForm.Customer;
                        db.SaveChanges();
                        dataGridView.Update();
                        dataGridView.Show();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var sellerChangeForm = new SellerAddForm(seller);
                    if (sellerChangeForm.ShowDialog() == DialogResult.OK)
                    {
                        seller = sellerChangeForm.Seller;
                        db.SaveChanges();
                        dataGridView.Update();
                        dataGridView.Show();
                    }
                }


            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    dataGridView.Update();
                    dataGridView.Show();
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    dataGridView.Update();
                    dataGridView.Show();

                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    db.Sellers.Remove(seller);
                    db.SaveChanges();
                    dataGridView.Update();
                    dataGridView.Show();
                }
            }
        }
    }
}
