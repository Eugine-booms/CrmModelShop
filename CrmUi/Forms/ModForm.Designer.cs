
namespace CrmUi.Forms
{
    partial class ModForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericUpDownCustomersCount = new System.Windows.Forms.NumericUpDown();
            this.labelCustomersCount = new System.Windows.Forms.Label();
            this.textBoxGone = new System.Windows.Forms.TextBox();
            this.labelGone = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelSumm = new System.Windows.Forms.Label();
            this.labelQueue = new System.Windows.Forms.Label();
            this.numericUpDownCashDeskStartCount = new System.Windows.Forms.NumericUpDown();
            this.labelCashDeskCount = new System.Windows.Forms.Label();
            this.numericUpDownCashDeskSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCustomerIncomingSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelCustomerIncamingSpeed = new System.Windows.Forms.Label();
            this.labelCashDeskSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCustomersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCashDeskStartCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCashDeskSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCustomerIncomingSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(512, 415);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(92, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Генерировать";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(610, 415);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericUpDownCustomersCount
            // 
            this.numericUpDownCustomersCount.Location = new System.Drawing.Point(668, 12);
            this.numericUpDownCustomersCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCustomersCount.Name = "numericUpDownCustomersCount";
            this.numericUpDownCustomersCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCustomersCount.TabIndex = 2;
            // 
            // labelCustomersCount
            // 
            this.labelCustomersCount.AutoSize = true;
            this.labelCustomersCount.Location = new System.Drawing.Point(569, 18);
            this.labelCustomersCount.Name = "labelCustomersCount";
            this.labelCustomersCount.Size = new System.Drawing.Size(73, 13);
            this.labelCustomersCount.TabIndex = 3;
            this.labelCustomersCount.Text = "Покупателей";
            // 
            // textBoxGone
            // 
            this.textBoxGone.Location = new System.Drawing.Point(668, 38);
            this.textBoxGone.Name = "textBoxGone";
            this.textBoxGone.Size = new System.Drawing.Size(100, 20);
            this.textBoxGone.TabIndex = 4;
            // 
            // labelGone
            // 
            this.labelGone.AutoSize = true;
            this.labelGone.Location = new System.Drawing.Point(569, 41);
            this.labelGone.Name = "labelGone";
            this.labelGone.Size = new System.Drawing.Size(101, 13);
            this.labelGone.TabIndex = 5;
            this.labelGone.Text = "Покупателей ушло";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(713, 415);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelSumm
            // 
            this.labelSumm.AutoSize = true;
            this.labelSumm.Location = new System.Drawing.Point(113, 9);
            this.labelSumm.Name = "labelSumm";
            this.labelSumm.Size = new System.Drawing.Size(50, 13);
            this.labelSumm.TabIndex = 7;
            this.labelSumm.Text = "Выручка";
            // 
            // labelQueue
            // 
            this.labelQueue.AutoSize = true;
            this.labelQueue.Location = new System.Drawing.Point(309, 9);
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.Size = new System.Drawing.Size(50, 13);
            this.labelQueue.TabIndex = 8;
            this.labelQueue.Text = "Очередь";
            // 
            // numericUpDownCashDeskStartCount
            // 
            this.numericUpDownCashDeskStartCount.Location = new System.Drawing.Point(512, 376);
            this.numericUpDownCashDeskStartCount.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownCashDeskStartCount.Name = "numericUpDownCashDeskStartCount";
            this.numericUpDownCashDeskStartCount.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownCashDeskStartCount.TabIndex = 9;
            this.numericUpDownCashDeskStartCount.ValueChanged += new System.EventHandler(this.numericUpDownCashDeskStartCount_ValueChanged);
            // 
            // labelCashDeskCount
            // 
            this.labelCashDeskCount.AutoSize = true;
            this.labelCashDeskCount.Location = new System.Drawing.Point(413, 378);
            this.labelCashDeskCount.Name = "labelCashDeskCount";
            this.labelCashDeskCount.Size = new System.Drawing.Size(93, 13);
            this.labelCashDeskCount.TabIndex = 10;
            this.labelCashDeskCount.Text = "Количество касс";
            // 
            // numericUpDownCashDeskSpeed
            // 
            this.numericUpDownCashDeskSpeed.Location = new System.Drawing.Point(515, 340);
            this.numericUpDownCashDeskSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCashDeskSpeed.Name = "numericUpDownCashDeskSpeed";
            this.numericUpDownCashDeskSpeed.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCashDeskSpeed.TabIndex = 11;
            this.numericUpDownCashDeskSpeed.ValueChanged += new System.EventHandler(this.numericUpDownCashDeskSpeed_ValueChanged);
            // 
            // numericUpDownCustomerIncomingSpeed
            // 
            this.numericUpDownCustomerIncomingSpeed.Location = new System.Drawing.Point(514, 310);
            this.numericUpDownCustomerIncomingSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCustomerIncomingSpeed.Name = "numericUpDownCustomerIncomingSpeed";
            this.numericUpDownCustomerIncomingSpeed.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCustomerIncomingSpeed.TabIndex = 12;
            this.numericUpDownCustomerIncomingSpeed.ValueChanged += new System.EventHandler(this.numericUpDownCustomerIncomingSpeed_ValueChanged);
            // 
            // labelCustomerIncamingSpeed
            // 
            this.labelCustomerIncamingSpeed.AutoSize = true;
            this.labelCustomerIncamingSpeed.Location = new System.Drawing.Point(359, 312);
            this.labelCustomerIncamingSpeed.Name = "labelCustomerIncamingSpeed";
            this.labelCustomerIncamingSpeed.Size = new System.Drawing.Size(149, 13);
            this.labelCustomerIncamingSpeed.TabIndex = 13;
            this.labelCustomerIncamingSpeed.Text = "Скорость прихода клиентов";
            // 
            // labelCashDeskSpeed
            // 
            this.labelCashDeskSpeed.AutoSize = true;
            this.labelCashDeskSpeed.Location = new System.Drawing.Point(384, 342);
            this.labelCashDeskSpeed.Name = "labelCashDeskSpeed";
            this.labelCashDeskSpeed.Size = new System.Drawing.Size(122, 13);
            this.labelCashDeskSpeed.TabIndex = 14;
            this.labelCashDeskSpeed.Text = "Скорость работы касс";
            // 
            // ModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCashDeskSpeed);
            this.Controls.Add(this.labelCustomerIncamingSpeed);
            this.Controls.Add(this.numericUpDownCustomerIncomingSpeed);
            this.Controls.Add(this.numericUpDownCashDeskSpeed);
            this.Controls.Add(this.labelCashDeskCount);
            this.Controls.Add(this.numericUpDownCashDeskStartCount);
            this.Controls.Add(this.labelQueue);
            this.Controls.Add(this.labelSumm);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelGone);
            this.Controls.Add(this.textBoxGone);
            this.Controls.Add(this.labelCustomersCount);
            this.Controls.Add(this.numericUpDownCustomersCount);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "ModForm";
            this.Text = "ModForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModForm_FormClosing);
            this.Load += new System.EventHandler(this.ModForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCustomersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCashDeskStartCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCashDeskSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCustomerIncomingSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownCustomersCount;
        private System.Windows.Forms.Label labelCustomersCount;
        private System.Windows.Forms.TextBox textBoxGone;
        private System.Windows.Forms.Label labelGone;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelSumm;
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.NumericUpDown numericUpDownCashDeskStartCount;
        private System.Windows.Forms.Label labelCashDeskCount;
        private System.Windows.Forms.NumericUpDown numericUpDownCashDeskSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownCustomerIncomingSpeed;
        private System.Windows.Forms.Label labelCustomerIncamingSpeed;
        private System.Windows.Forms.Label labelCashDeskSpeed;
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}