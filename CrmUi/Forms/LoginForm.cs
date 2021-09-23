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

namespace CrmUi.Forms
{
    public partial class LoginForm : Form
    {
        public Customer Customer { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBoxName.Text
            };
            DialogResult = DialogResult.OK;
        }

        private void LoginForm_Enter(object sender, EventArgs e)=>button1_Click(sender, e);
        

    }
}
