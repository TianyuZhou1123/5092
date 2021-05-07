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
    public partial class NewInstrument : Form
    {
        public NewInstrument()
        {
            InitializeComponent();
        }

        private void NewInstrument_Load(object sender, EventArgs e)
        {
            //select Stocks, if Ticker is new, store it
            foreach (var i in (from j in Program.PMC.Instruments where j.InstType.Typename == "Stock" select j))
            {
               // comboBox_underlying.Enabled = true;
                if (!comboBox_underlying.Items.Contains(i.Ticker))
                    comboBox_underlying.Items.Add(i.Ticker);
            }
            //if not exist rows in instrument, show a messagebox and exit
            if ((from j in Program.PMC.InstTypes select j).Count() != 0)
            {
                //clear instrument type and reload
                comboBox_insttype.Items.Clear();
                foreach (InstType i in (from j in Program.PMC.InstTypes select j))
                    comboBox_insttype.Items.Add(i.Typename);
                //initialize
                comboBox_insttype.Text = Convert.ToString(comboBox_insttype.Items[0]);
                radioButton_neither.Checked = true;
                textBox_K.Enabled = false;
                textBox_T.Enabled = false;
                textBox_rebate.Enabled = false;
                textBox_barrier.Enabled = false;
                comboBox_barriertype.Enabled = false;
                //stock
                if (comboBox_insttype.Text == "Stock")
                {
                    radioButton_neither.Checked = true;
                    textBox_K.Enabled = false;
                    textBox_T.Enabled = false;
                    textBox_rebate.Enabled = false;
                    textBox_barrier.Enabled = false;
                    comboBox_barriertype.Enabled = false;
                    comboBox_underlying.Enabled = false;
                }
                //option
                else
                {
                    comboBox_underlying.Enabled = true;
                    radioButton_call.Checked = true;
                    textBox_K.Enabled = true;
                    textBox_T.Enabled = true;
                    if (comboBox_insttype.Text == "DigitalOption")
                    {
                        textBox_rebate.Enabled = true;
                        textBox_barrier.Enabled = false;
                        comboBox_barriertype.Enabled = false;
                    }
                    if (comboBox_insttype.Text == "BarrierOption")
                    {
                        textBox_rebate.Enabled = false;
                        textBox_barrier.Enabled = true;
                        comboBox_barriertype.Enabled = true;
                        comboBox_barriertype.Text = Convert.ToString(comboBox_barriertype.Items[0]);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data in Instrument!");
                this.Dispose();
            }
        }
        private void comboBox_insttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_insttype.Text == "Stock")
            {
                radioButton_neither.Checked = true;
                textBox_K.Enabled = false;
                textBox_T.Enabled = false;
                textBox_rebate.Enabled = false;
                textBox_barrier.Enabled = false;
                comboBox_barriertype.Enabled = false;
                comboBox_underlying.Enabled = false;
            }
            else
            {
                comboBox_underlying.Enabled = true;
                radioButton_call.Checked = true;
                textBox_K.Enabled = true;
                textBox_T.Enabled = true;
                //digital
                if (comboBox_insttype.Text == "DigitalOption")
                {
                    textBox_rebate.Enabled = true;
                    textBox_barrier.Enabled = false;
                    comboBox_barriertype.Enabled = false;
                }
                //barrier
                if (comboBox_insttype.Text == "BarrierOption")
                {
                    textBox_rebate.Enabled = false;
                    textBox_barrier.Enabled = true;
                    comboBox_barriertype.Enabled = true;
                    comboBox_barriertype.Text = Convert.ToString(comboBox_barriertype.Items[0]);
                }
            }
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            //if missing data
            if (textBox_cname.Text == String.Empty || textBox_ticker.Text == String.Empty
                || textBox_exchange.Text == String.Empty || comboBox_insttype.Text == String.Empty)
                MessageBox.Show("Missing some inputs.");
            else
            {
                InstType instType = (from i in Program.PMC.InstTypes where i.Typename == comboBox_insttype.Text select i).FirstOrDefault();
                var query = from i in Program.PMC.Instruments where i.InstType.Typename == "Stock" select i.Ticker;
                //justify where the ticker exists
                bool same_ticker = false;
                foreach (string i in query)
                {
                    if (i.Contains(textBox_ticker.Text))
                        same_ticker = true;
                }
                if (!same_ticker)
                {
                    if (comboBox_insttype.Text == "Stock")
                    {
                        Program.PMC.Instruments.Add(new Instrument()
                        {
                            CompanyName = textBox_cname.Text,
                            Ticker = textBox_ticker.Text,
                            Exchange = textBox_exchange.Text,
                            Underlying = "",
                            InstType = instType
                        });
                        Program.PMC.SaveChanges();
                        MessageBox.Show("Add successfully!");
                        this.Dispose();
                    }
                    else
                    {
                        if (comboBox_insttype.Text == "DigitalOption")
                        {
                            if (textBox_K.Text == String.Empty || textBox_T.Text == String.Empty
                                || textBox_rebate.Text == String.Empty || comboBox_underlying.Text == String.Empty)
                                MessageBox.Show("Missing some data.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_cname.Text,
                                    Ticker = textBox_ticker.Text,
                                    Exchange = textBox_exchange.Text,
                                    Underlying = comboBox_underlying.Text,
                                    Strike = Convert.ToDouble(textBox_K.Text),
                                    Tenor = Convert.ToDouble(textBox_T.Text),
                                    IsCall = radioButton_call.Checked,
                                    Rebate = Convert.ToDouble(textBox_rebate.Text),
                                    Barrier = 0,
                                    BarrierType = "",
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }
                        else if (comboBox_insttype.Text == "BarrierOption")
                        {
                            if (textBox_K.Text == String.Empty || textBox_T.Text == String.Empty
                                || textBox_barrier.Text == String.Empty || comboBox_barriertype.Text == String.Empty
                                || comboBox_underlying.Text == String.Empty)
                                MessageBox.Show("Missing input.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_cname.Text,
                                    Ticker = textBox_ticker.Text,
                                    Exchange = textBox_exchange.Text,
                                    Underlying = comboBox_underlying.Text,
                                    Strike = Convert.ToDouble(textBox_K.Text),
                                    Tenor = Convert.ToDouble(textBox_T.Text),
                                    IsCall = radioButton_call.Checked,
                                    Rebate = 0,
                                    Barrier = Convert.ToDouble(textBox_barrier.Text),
                                    BarrierType = comboBox_barriertype.Text,
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }
                        //other option
                        else
                        {
                            if (textBox_K.Text == String.Empty || textBox_T.Text == String.Empty
                            || comboBox_underlying.Text == String.Empty)
                                MessageBox.Show("Missing input.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_cname.Text,
                                    Ticker = textBox_ticker.Text,
                                    Exchange = textBox_exchange.Text,
                                    Underlying = comboBox_underlying.Text,
                                    Strike = Convert.ToDouble(textBox_K.Text),
                                    Tenor = Convert.ToDouble(textBox_T.Text),
                                    IsCall = radioButton_call.Checked,
                                    Rebate = 0,
                                    Barrier = 0,
                                    BarrierType = "",
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }

                    }
                }
                else
                    MessageBox.Show("Already exist.");
            }
        }
        private void comboBox_underlying_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var query in (from i in Program.PMC.Instruments where i.Ticker == comboBox_underlying.Text select i))
                textBox_cname.Text = query.CompanyName;
        }
    }
}
