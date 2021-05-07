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
    public partial class NewTrade : Form
    {
        public NewTrade()
        {
            InitializeComponent();
            RefershInstrument();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            //if missing data
            if (textBox_quantity.Text == String.Empty || textBox_price.Text == String.Empty
                || comboBox_instrument.Text == String.Empty)
                MessageBox.Show("Missing input");
            else
            {
                Instrument instrument = (from i in Program.PMC.Instruments where i.Ticker == comboBox_instrument.Text select i).FirstOrDefault();
                Program.PMC.Trades.Add(new Trade()
                {
                    IsBuy = radioButton_buy.Checked,
                    Quantity = Convert.ToDouble(textBox_quantity.Text),
                    Price = Convert.ToDouble(textBox_price.Text),
                    Timestamp = DateTime.Now,
                    Instrument = instrument
                });
                Program.PMC.SaveChanges();
                MessageBox.Show("Add successfully!");
                this.Dispose();
            }
        }
        private void RefershInstrument()
        {
            comboBox_instrument.Items.Clear();
            foreach (Instrument i in Program.PMC.Instruments)
                comboBox_instrument.Items.Add(i.Ticker);
        }

        private void NewTrade_Load(object sender, EventArgs e)
        {

        }
    }
}
