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
    public partial class SellerAddForm : CrmUi.BaseAddForm
    {
        public Seller Seller { get; internal set; }
        public SellerAddForm()
        {
            InitializeComponent();
        }
        public SellerAddForm(Seller seller) : this()
        {
            Seller = seller;
        }

        private void SellerAddForm_Load(object sender, EventArgs e)
        {
            if (Seller!=null)
            {
                textBoxName.Text = Seller.Name;
            }
        }

        protected override void button1_Click(object sender, EventArgs e)
        {
            var seller = Seller ?? new Seller();

            seller.Name = textBoxName.Text;
            this.Seller = seller;
            Close();
        }
    }
}
