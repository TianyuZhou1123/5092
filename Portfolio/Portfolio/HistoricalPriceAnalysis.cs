using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio
{
    public partial class HistoricalPriceAnalysis : Form
    {
        public HistoricalPriceAnalysis()
        {
            InitializeComponent();
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void HistoricalPriceAnalysis_Load(object sender, EventArgs e)
        {
            //load data from SQL
            var query = from i in Program.PMC.Instruments join j in Program.PMC.InstTypes on i.TypeID equals j.ID where j.Typename == "Stock" select i.Ticker;
            List<string> ticker = new List<string>();
            foreach (var i in query)
                ticker.Add(i);
            comboBox_instrument.DisplayMember = ticker[0];
            comboBox_instrument.DataSource = ticker;
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.StockPrices where i.Instrument.Ticker == comboBox_instrument.Text select i;
            foreach (StockPrice price in Query)
                dataGridView1.Rows.Add(price.Date.ToString(), price.ClosingPrice);//改
        }

        private void comboBox_instrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.StockPrices where i.Instrument.Ticker == comboBox_instrument.Text select i;
            foreach (StockPrice price in Query)
                dataGridView1.Rows.Add(price.Date.ToString(), price.ClosingPrice);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip.Show(this.dataGridView1, e.Location);
                ContextMenuStrip.Show(Cursor.Position);
            }
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            foreach (DataGridViewRow i in dataGridView1.SelectedRows)
            {
                DateTime newdata = new DateTime();
                newdata = Convert.ToDateTime(i.Cells[0].Value);
                Program.PMC.StockPrices.Remove((from j in Program.PMC.StockPrices where j.Date == newdata select j).FirstOrDefault());
            }
            Program.PMC.SaveChanges();
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.StockPrices where i.Instrument.Ticker == comboBox_instrument.Text select i;
            foreach (StockPrice price in Query)
                dataGridView1.Rows.Add(price.Date.ToString(), price.ClosingPrice);
        }
    }
}
