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
        public ProductAddForm(Product product) : this()
        {
            Product = product?? new Product() ;
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            labelName.Text = "Название продукта";
            if (Product != null)
            {
                textBoxName.Text = Product.Name;
                numericUpDownPrice.Value = Product.Price;
                numericUpDownCount.Value = Product.Count;
            }
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            var p = this.Product ?? new Product();
            p.Name = textBoxName.Text;
            p.Price = numericUpDownPrice.Value;
            p.Count = Convert.ToInt32(numericUpDownCount.Value);
            this.Product = p;
            Close();
        }


    }
}
