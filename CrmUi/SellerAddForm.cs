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
    public partial class SellerAddForm : CrmUi.AddFormBase
    {
        public Seller Seller { get; internal set; }
        public SellerAddForm()
        {
            InitializeComponent();
        }

        private void SellerAddForm_Load(object sender, EventArgs e)
        {

        }

        protected override void button1_Click(object sender, EventArgs e)
        {
            Seller = new Seller() { Name = textBox1.Text };
            Close();
        }
    }
}
