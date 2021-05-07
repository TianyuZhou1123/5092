
namespace Portfolio
{
    partial class MainScreen
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTradesFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceBookUsingSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_vol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_Total = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.listView_alltrade = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1347, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refreshTradesFromDatabaseToolStripMenuItem,
            this.priceBookUsingSimulationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentTypeToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.tradeToolStripMenuItem,
            this.interestRateToolStripMenuItem,
            this.historicalPriceToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.newToolStripMenuItem.Text = "New";
            // 
            // instrumentTypeToolStripMenuItem
            // 
            this.instrumentTypeToolStripMenuItem.Name = "instrumentTypeToolStripMenuItem";
            this.instrumentTypeToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.instrumentTypeToolStripMenuItem.Text = "Instrument type";
            this.instrumentTypeToolStripMenuItem.Click += new System.EventHandler(this.instrumentTypeToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.tradeToolStripMenuItem.Text = "Trade";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.tradeToolStripMenuItem_Click);
            // 
            // interestRateToolStripMenuItem
            // 
            this.interestRateToolStripMenuItem.Name = "interestRateToolStripMenuItem";
            this.interestRateToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.interestRateToolStripMenuItem.Text = "Interest rate";
            this.interestRateToolStripMenuItem.Click += new System.EventHandler(this.interestRateToolStripMenuItem_Click);
            // 
            // historicalPriceToolStripMenuItem
            // 
            this.historicalPriceToolStripMenuItem.Name = "historicalPriceToolStripMenuItem";
            this.historicalPriceToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.historicalPriceToolStripMenuItem.Text = "Historical price";
            this.historicalPriceToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceToolStripMenuItem_Click);
            // 
            // refreshTradesFromDatabaseToolStripMenuItem
            // 
            this.refreshTradesFromDatabaseToolStripMenuItem.Name = "refreshTradesFromDatabaseToolStripMenuItem";
            this.refreshTradesFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.refreshTradesFromDatabaseToolStripMenuItem.Text = "Refresh trades from database";
            this.refreshTradesFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.refreshTradesFromDatabaseToolStripMenuItem_Click);
            // 
            // priceBookUsingSimulationToolStripMenuItem
            // 
            this.priceBookUsingSimulationToolStripMenuItem.Name = "priceBookUsingSimulationToolStripMenuItem";
            this.priceBookUsingSimulationToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.priceBookUsingSimulationToolStripMenuItem.Text = "Price book using simulation";
            this.priceBookUsingSimulationToolStripMenuItem.Click += new System.EventHandler(this.priceBookUsingSimulationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicalPriceAnalysisToolStripMenuItem,
            this.interestRateAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(96, 28);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // historicalPriceAnalysisToolStripMenuItem
            // 
            this.historicalPriceAnalysisToolStripMenuItem.Name = "historicalPriceAnalysisToolStripMenuItem";
            this.historicalPriceAnalysisToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.historicalPriceAnalysisToolStripMenuItem.Text = "Historical price analysis";
            this.historicalPriceAnalysisToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceAnalysisToolStripMenuItem_Click);
            // 
            // interestRateAnalysisToolStripMenuItem
            // 
            this.interestRateAnalysisToolStripMenuItem.Name = "interestRateAnalysisToolStripMenuItem";
            this.interestRateAnalysisToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.interestRateAnalysisToolStripMenuItem.Text = "Interest rate analysis";
            this.interestRateAnalysisToolStripMenuItem.Click += new System.EventHandler(this.interestRateAnalysisToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDataToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(88, 28);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // generateDataToolStripMenuItem
            // 
            this.generateDataToolStripMenuItem.Name = "generateDataToolStripMenuItem";
            this.generateDataToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.generateDataToolStripMenuItem.Text = "Generate data";
            this.generateDataToolStripMenuItem.Click += new System.EventHandler(this.generateDataToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pricing volatility(%)";
            // 
            // textBox_vol
            // 
            this.textBox_vol.Location = new System.Drawing.Point(213, 48);
            this.textBox_vol.Name = "textBox_vol";
            this.textBox_vol.Size = new System.Drawing.Size(100, 28);
            this.textBox_vol.TabIndex = 2;
            this.textBox_vol.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Totals:";
            // 
            // listView_Total
            // 
            this.listView_Total.HideSelection = false;
            this.listView_Total.Location = new System.Drawing.Point(25, 115);
            this.listView_Total.Name = "listView_Total";
            this.listView_Total.Size = new System.Drawing.Size(1322, 81);
            this.listView_Total.TabIndex = 4;
            this.listView_Total.UseCompatibleStateImageBehavior = false;
            this.listView_Total.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "All trades:";
            // 
            // listView_alltrade
            // 
            this.listView_alltrade.HideSelection = false;
            this.listView_alltrade.Location = new System.Drawing.Point(25, 249);
            this.listView_alltrade.Name = "listView_alltrade";
            this.listView_alltrade.Size = new System.Drawing.Size(1322, 245);
            this.listView_alltrade.TabIndex = 6;
            this.listView_alltrade.UseCompatibleStateImageBehavior = false;
            this.listView_alltrade.View = System.Windows.Forms.View.Details;
            this.listView_alltrade.SelectedIndexChanged += new System.EventHandler(this.listView_alltrade_SelectedIndexChanged);
            this.listView_alltrade.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_alltrade_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 67);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 570);
            this.Controls.Add(this.listView_alltrade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView_Total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_vol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshTradesFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceBookUsingSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDataToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_vol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_Total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView_alltrade;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

