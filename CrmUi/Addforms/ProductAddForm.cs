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
    public partial class ProductAddForm : CrmUi.BaseAddForm
    {
        public Product Product { get; internal set; }
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            labelName.Text = "Название продукта";
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            Product = new Product();
            Product.Name = textBoxName.Text;
            Product.Price = numericUpDownPrice.Value;
            Product.Count =Convert.ToInt32( numericUpDownCount.Value);
            Close();
        }


    }
}
