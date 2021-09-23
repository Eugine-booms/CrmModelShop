using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi.Forms
{
    class CashDeskView
    {
        public CashDesk CashDesk { get; set; }
        public Label LabelCashDeskName { get; set; }
        public NumericUpDown CheckSumm { get; set; }
        public ProgressBar QueueBar { get; set; }
        public Label LabelOutCustomersCount { get; set; }

        public CashDeskView()
        {
        }

        public CashDeskView(CashDesk cashDesk,int x, int y)
        {
            this.CashDesk = cashDesk;
            LabelCashDeskName = new Label();
            CheckSumm = new NumericUpDown();
            QueueBar = new ProgressBar();
            LabelOutCustomersCount = new Label();

            // 
            // LabelCashDeskName
            // 
            LabelCashDeskName.AutoSize = true;
            LabelCashDeskName.Location = new System.Drawing.Point(x, y);
            LabelCashDeskName.Name = "label" + cashDesk;
            LabelCashDeskName.Size = new System.Drawing.Size(35, 13);
            LabelCashDeskName.TabIndex = cashDesk.Number;
            LabelCashDeskName.Text = cashDesk.ToString();
            // 
            // numericCheckSumm
            // 
            CheckSumm.Location = new System.Drawing.Point(x + 80, y - 2);
            CheckSumm.Name = "numericUpDown" + cashDesk.Number;
            CheckSumm.Size = new System.Drawing.Size(200, 20);
            CheckSumm.TabIndex = cashDesk.Number;
            CheckSumm.Maximum = decimal.MaxValue;
            CheckSumm.DecimalPlaces = 2;
            cashDesk.ChekOut += CashDesk_ChekOut;
            // 
            // numericQueueCustomerSize
            // 
            LabelOutCustomersCount.AutoSize = true;
            LabelOutCustomersCount.Location = new System.Drawing.Point(x + 285, y - 2);
            LabelOutCustomersCount.Name = "label" + cashDesk+"OutPiople";
            LabelOutCustomersCount.Size = new System.Drawing.Size(35, 13);
            LabelOutCustomersCount.TabIndex = cashDesk.Number;
            // 
            // progressBar1
            // 
            QueueBar.Location = new System.Drawing.Point(x + 390, y - 2);
            QueueBar.Name = "progressBar"+ cashDesk.Number;
            QueueBar.Size = new System.Drawing.Size(100, 23);
            QueueBar.TabIndex = 7;
            QueueBar.Minimum = 0;
            QueueBar.Style = ProgressBarStyle.Continuous;
            QueueBar.Maximum = cashDesk.GetMaxQueueLenght();
            cashDesk.QueueCartsChanged += CashDesk_QueueCartsChanged;
        }

        private void CashDesk_QueueCartsChanged(object sender, int e)
        {
            QueueBar.Invoke((Action)delegate
            {
                QueueBar.Value = e;
                LabelOutCustomersCount.Text=CashDesk.ExitCustomerCount.ToString();
                
            });
        }

        private void CashDesk_ChekOut(object sender, Check e)
        {
            CheckSumm.Invoke((Action) delegate 
            { 
                CheckSumm.Value += e.Summ;
            });
        }

    }
}
