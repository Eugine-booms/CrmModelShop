using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrmUi
{

    public partial class CustomerAddForm : CrmUi.BaseAddForm
    {
        public Customer Customer { get; set; }
        public CustomerAddForm()
        {
            InitializeComponent();
        }
        public CustomerAddForm(Customer customer) : this()
        {
            this.Customer = customer;
        }

        private void CustomerAddForm_Load(object sender, EventArgs e)
        {
            if (Customer!=null)
            {
                textBoxName.Text = Customer.Name;
            }
            
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            var customer = this.Customer ?? new Customer();
            customer.Name = textBoxName.Text;
            this.Customer = customer;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
