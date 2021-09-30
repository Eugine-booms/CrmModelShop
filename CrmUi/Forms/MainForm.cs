using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl.Model;
using CrmUi.Forms;

namespace CrmUi
{
    public partial class Main : Form
    {
        CrmContext db;
        Cart cart;
        Customer customer;
        CashDesk cashDesk;


        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
            customer = new Customer();
            cart = new Cart(customer);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBoxProducts.Invoke((Action)delegate
                {
                    listBoxProducts.Items.AddRange(db.Products.ToArray());
                    listBoxCart.Items.AddRange(cart.GetAllProduct().ToArray());
                });

            });

        }
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProducts = new Catalog<Product>(db, db.Products);
            catalogProducts.Show();
            UpdateLists();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSellers = new Catalog<Seller>(db, db.Sellers);
            catalogSellers.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomers = new Catalog<Customer>(db, db.Customers);
            catalogCustomers.Show();
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
            UpdateLists();

        }

        private void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modForm = new ModForm();
            modForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxProducts_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItem is Product product)
            {
                cart.Add(product);
                UpdateLists();
            }


        }
        private void UpdateLists()
        {
            listBoxProducts.Items.Clear();
            listBoxProducts.Items.AddRange(db.Products.ToArray());
            listBoxCart.Items.Clear();
            listBoxCart.Items.AddRange(cart.GetAllProduct().ToArray());
            labelSumm.Text = "Итого; " + cart.ReturnSumProduct().ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var user = db.Customers.FirstOrDefault(c => c.Name.Equals(loginForm.Customer.Name));
                if (user != null)
                {
                    customer = user;
                    cart.Customer = customer;
                }
                else
                {
                    var addCustomerForm = new CustomerAddForm(customer);
                    if (addCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        customer = addCustomerForm.Customer;
                        cart.Customer = customer;
                    }
                }
                linkLabel1.Text = "Здравствуй " + customer.Name;
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (customer.Name != null)
            {
                cashDesk = new CashDesk(1, db.Sellers.FirstOrDefault(), 10, db);
                cashDesk.IsModel = false;
                cashDesk.Enqueue(cart);
                var check = cashDesk.SingleCustomerService(cart);


                cart = new Cart(customer);


                CheckPrint(check);
                listBoxCart.Items.Clear();
                //TODO: Печать чека
            }
            else
            {
                MessageBox.Show("Авторизуйтесь пожалуйста", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CheckPrint(Check check)
        {
            textBoxCheck.Clear();
            textBoxCheck.Text = "ООО Рога и копыта" + Environment.NewLine;
            textBoxCheck.Text += "Чек "+check + Environment.NewLine;
            textBoxCheck.Text += "Продавец: " + db.Sellers.Find(check.SellerId) + Environment.NewLine;
            textBoxCheck.Text += "Покупатель: " + db.Customers.Find(check.CustomerId) + Environment.NewLine;
            textBoxCheck.Text += "//////////////////////////" + Environment.NewLine;
            var checkproducts = db.Sells
                .Where(x => x.CheckId == check.CheckId)
                .Select(s => s.ProductId)
                .SelectMany(s => db.Products
                                .Where(x => x.ProductId == s))
                .ToList();
            foreach (var item in checkproducts)
            {
                textBoxCheck.Text += item.ToString() + Environment.NewLine;
            }
            textBoxCheck.Text += "//////////////////////////" + Environment.NewLine;
            textBoxCheck.Text += "Сумма: " + check.Summ + Environment.NewLine;
        }

      
    }
}
