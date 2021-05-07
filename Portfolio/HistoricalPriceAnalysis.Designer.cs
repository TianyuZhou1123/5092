
namespace Portfolio
{
    partial class HistoricalPriceAnalysis
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_instrument = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_close = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Instrument:";
            // 
            // comboBox_instrument
            // 
            this.comboBox_instrument.FormattingEnabled = true;
            this.comboBox_instrument.Location = new System.Drawing.Point(336, 35);
            this.comboBox_instrument.Name = "comboBox_instrument";
            this.comboBox_instrument.Size = new System.Drawing.Size(263, 26);
            this.comboBox_instrument.TabIndex = 1;
            this.comboBox_instrument.SelectedIndexChanged += new System.EventHandler(this.comboBox_instrument_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.ClosingPrice});
            this.dataGridView1.Location = new System.Drawing.Point(88, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(594, 314);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(583, 433);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(99, 34);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 34);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // ClosingPrice
            // 
            this.ClosingPrice.HeaderText = "Closing Price";
            this.ClosingPrice.MinimumWidth = 8;
            this.ClosingPrice.Name = "ClosingPrice";
            this.ClosingPrice.Width = 267;
            // 
            // HistoricalPriceAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_instrument);
            this.Controls.Add(this.label1);
            this.Name = "HistoricalPriceAnalysis";
            this.Text = "HistoricalPriceAnalysis";
            this.Load += new System.EventHandler(this.HistoricalPriceAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_instrument;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingPrice;
    }
}