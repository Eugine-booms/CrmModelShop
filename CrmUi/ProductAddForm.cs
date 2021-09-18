using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
   
    public partial class ProductAddForm : Form
    {
        public Product Product { get; set; }
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int.TryParse(priceBox.Text, out int price);
            int.TryParse(countBox.Text, out int count);
            Product = new Product()
            {
                Name = NameBox.Text,
                Price= price,
                Count = count
            };


        }
    }
}
