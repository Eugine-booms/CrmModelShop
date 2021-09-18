
namespace CrmUi
{
    partial class ProductAddForm
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.countLable = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.countBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(280, 169);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(12, 20);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(106, 13);
            this.productNameLabel.TabIndex = 1;
            this.productNameLabel.Text = "Название продукта";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(12, 58);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(33, 13);
            this.PriceLabel.TabIndex = 2;
            this.PriceLabel.Text = "Цена";
            // 
            // countLable
            // 
            this.countLable.AutoSize = true;
            this.countLable.Location = new System.Drawing.Point(12, 99);
            this.countLable.Name = "countLable";
            this.countLable.Size = new System.Drawing.Size(72, 13);
            this.countLable.TabIndex = 3;
            this.countLable.Text = "Колличество";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(124, 17);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(231, 20);
            this.NameBox.TabIndex = 4;
            this.NameBox.Text = "Название";
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(124, 55);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(100, 20);
            this.priceBox.TabIndex = 5;
            this.priceBox.Text = "0 ";
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(124, 96);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(100, 20);
            this.countBox.TabIndex = 6;
            this.countBox.Text = "0";
            // 
            // ProductAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 204);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.countLable);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.buttonSave);
            this.Name = "ProductAddForm";
            this.Text = "Добавление продукта";
            this.Load += new System.EventHandler(this.ProductAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label countLable;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.TextBox countBox;
    }
}