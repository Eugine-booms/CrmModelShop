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
    public partial class ModForm : Form
    {
        ShopComputerModel model;
        public ModForm()
        {
            InitializeComponent();
            model = new ShopComputerModel();
        }

        private void ModForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            model.GenerateCashDesk((int)numericUpDownCashDeskStartCount.Value);
            var cashDeskViewList = new List<CashDeskView>();

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashDeskView(model.CashDesks[i], 10, i * 26 + 26);
                cashDeskViewList.Add(box);
                this.Controls.Add(box.LabelCashDeskName);
                this.Controls.Add(box.CheckSumm);
                this.Controls.Add(box.LabelOutCustomersCount);
                
                Controls.Add(box.QueueBar);
            }
            model.CartsQueueChanged += Model_CartsQueueChanged;
            buttonStart.Enabled = true;
        }

        private void Model_CartsQueueChanged(object sender, int e)
        {
            numericUpDownCustomersCount.Invoke(
                                     (Action)delegate
                                     {
                                         numericUpDownCustomersCount.Value = Convert.ToDecimal(e);
                                     });
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            model.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            model.Stop();
        }

        private void ModForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void numericUpDownCashDeskSpeed_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeedDelay = (11-(int)numericUpDownCashDeskSpeed.Value)*1000;
        }

        private void numericUpDownCustomerIncomingSpeed_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeedDelay= (11 - (int)numericUpDownCustomerIncomingSpeed.Value) * 1000;
        }

        private void numericUpDownCashDeskStartCount_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskCount=(int)numericUpDownCashDeskStartCount.Value;
        }
    }
}
