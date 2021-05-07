
namespace Portfolio
{
    partial class NewTrade
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_buy = new System.Windows.Forms.RadioButton();
            this.radioButton_sell = new System.Windows.Forms.RadioButton();
            this.textBox_quantity = new System.Windows.Forms.TextBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.comboBox_instrument = new System.Windows.Forms.ComboBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Direction:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instrument:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price:";
            // 
            // radioButton_buy
            // 
            this.radioButton_buy.AutoSize = true;
            this.radioButton_buy.Location = new System.Drawing.Point(267, 42);
            this.radioButton_buy.Name = "radioButton_buy";
            this.radioButton_buy.Size = new System.Drawing.Size(60, 22);
            this.radioButton_buy.TabIndex = 4;
            this.radioButton_buy.TabStop = true;
            this.radioButton_buy.Text = "Buy";
            this.radioButton_buy.UseVisualStyleBackColor = true;
            // 
            // radioButton_sell
            // 
            this.radioButton_sell.AutoSize = true;
            this.radioButton_sell.Location = new System.Drawing.Point(390, 42);
            this.radioButton_sell.Name = "radioButton_sell";
            this.radioButton_sell.Size = new System.Drawing.Size(69, 22);
            this.radioButton_sell.TabIndex = 5;
            this.radioButton_sell.TabStop = true;
            this.radioButton_sell.Text = "Sell";
            this.radioButton_sell.UseVisualStyleBackColor = true;
            // 
            // textBox_quantity
            // 
            this.textBox_quantity.Location = new System.Drawing.Point(267, 89);
            this.textBox_quantity.Name = "textBox_quantity";
            this.textBox_quantity.Size = new System.Drawing.Size(202, 28);
            this.textBox_quantity.TabIndex = 6;
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(267, 188);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(202, 28);
            this.textBox_price.TabIndex = 7;
            // 
            // comboBox_instrument
            // 
            this.comboBox_instrument.FormattingEnabled = true;
            this.comboBox_instrument.Location = new System.Drawing.Point(267, 140);
            this.comboBox_instrument.Name = "comboBox_instrument";
            this.comboBox_instrument.Size = new System.Drawing.Size(202, 26);
            this.comboBox_instrument.TabIndex = 8;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(252, 256);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(88, 35);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(394, 256);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(84, 35);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // NewTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_instrument);
            this.Controls.Add(this.textBox_price);
            this.Controls.Add(this.textBox_quantity);
            this.Controls.Add(this.radioButton_sell);
            this.Controls.Add(this.radioButton_buy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewTrade";
            this.Text = "NewTrade";
            this.Load += new System.EventHandler(this.NewTrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_buy;
        private System.Windows.Forms.RadioButton radioButton_sell;
        private System.Windows.Forms.TextBox textBox_quantity;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.ComboBox comboBox_instrument;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
    }
}