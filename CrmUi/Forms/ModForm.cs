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
        List<CashDeskView> cashDeskViewList;
        public ModForm()
        {
            InitializeComponent();
            model = new ShopComputerModel();
            cashDeskViewList = new List<CashDeskView>();
        }

        private void ModForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            model.GenerateCashDesk((int)numericUpDownCashDeskStartCount.Value);
            

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashDeskView(model.CashDesks[i], 10, i * 26 + 26);
                cashDeskViewList.Add(box);
                this.Controls.Add(box.LabelCashDeskName);
                this.Controls.Add(box.CheckSumm);
                this.Controls.Add(box.LabelOutCustomersCount);
                Controls.Add(box.QueueBar);
            }
           
            buttonStart.Enabled = true;
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
            foreach (var view in cashDeskViewList)
            {
                view.CashDesk.ChekOut -= view.CashDesk_ChekOut;
                view.CashDesk.QueueCartsChanged -= view.CashDesk_QueueCartsChanged;
            }
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
