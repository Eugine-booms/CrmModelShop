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
        public Label Label { get; set; }
        public NumericUpDown CheckSumm { get; set; }
        public NumericUpDown QueueCustomerSize { get; set; }
        public ProgressBar QueueBar { get; set; }

        public CashDeskView()
        {
        }

        public CashDeskView(CashDesk cashDesk,int x, int y)
        {
            this.CashDesk = cashDesk;
            Label = new Label();
            CheckSumm = new NumericUpDown();
            QueueCustomerSize = new NumericUpDown();
            QueueBar = new ProgressBar();
            // 
            // label1
            // 
            Label.AutoSize = true;
            Label.Location = new System.Drawing.Point(x, y);
            Label.Name = "label" + cashDesk;
            Label.Size = new System.Drawing.Size(35, 13);
            Label.TabIndex = cashDesk.Number;
            Label.Text = cashDesk.ToString();
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
            QueueCustomerSize.Location = new System.Drawing.Point(x + 285, y - 2);
            QueueCustomerSize.Name = "numericUpDown" + cashDesk.Number;
            QueueCustomerSize.Size = new System.Drawing.Size(50, 20);
            QueueCustomerSize.TabIndex = cashDesk.Number;
            QueueCustomerSize.Maximum = 1000;
             cashDesk.QueueCartsChanged += CashDesk_QueueCartsChanged;
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
        }

        private void CashDesk_QueueCartsChanged(object sender, int e)
        {
            QueueCustomerSize.Invoke((Action)delegate
            {
                QueueCustomerSize.Value = e;
                QueueBar.Value = e;
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
