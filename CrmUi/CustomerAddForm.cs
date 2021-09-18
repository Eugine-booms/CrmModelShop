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
   
    public partial class CustomerAddForm : CrmUi.AddFormBase
    {
        public Customer Customer { get; set; }
        public CustomerAddForm()
        {
            InitializeComponent();
        }

        private void CustomerAddForm_Load(object sender, EventArgs e)
        {

        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer() { Name = textBox1.Text };
            Close();
        }
    }
}
