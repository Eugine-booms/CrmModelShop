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
    public partial class ProductAddForm : CrmUi.AddFormBase
    {
        public Product Product { get; internal set; }
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Название продукта";
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            Product = new Product();
            Product.Name = textBox1.Text;
            int.TryParse(textBox2.Text, out int price);
            Product.Price = price;
            int.TryParse(textBox3.Text, out int count);
            Product.Count = count;
            Close();
        }
    }
}
