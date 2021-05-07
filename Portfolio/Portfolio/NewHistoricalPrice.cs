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
    public partial class NewHistoricalPrice : Form
    {
        public NewHistoricalPrice()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_ClosingPrice.Text == String.Empty || comboBox_Product.Text == String.Empty)
                MessageBox.Show("Missing data.");
            else
            {
                Program.PMC.StockPrices.Add(new StockPrice()
                {
                    InstrumentID = (from i in Program.PMC.Instruments where i.Ticker == comboBox_Product.Text select i.ID).FirstOrDefault(),
                    Date = dateTimePicker1.Value,
                    ClosingPrice = Convert.ToDouble(textBox_ClosingPrice.Text)
                });
                Program.PMC.SaveChanges();
                MessageBox.Show("Add successfully!");
            }
        }

        private void NewHistoricalPrice_Load(object sender, EventArgs e)
        {

        }
    }
}
