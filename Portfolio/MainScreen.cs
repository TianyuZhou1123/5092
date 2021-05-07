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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add columns into GUI
            listView_Total.Columns.Add("Total P&L",80);
            listView_Total.Columns.Add("Total delta",80);
            listView_Total.Columns.Add("Total gamma",80);
            listView_Total.Columns.Add("Total vega",80);
            listView_Total.Columns.Add("Total theta",80);
            listView_Total.Columns.Add("Total rho",80);
            listView_alltrade.Columns.Add("ID", 25);
            listView_alltrade.Columns.Add("Diection", 70);
            listView_alltrade.Columns.Add("Quantity", 70);
            listView_alltrade.Columns.Add("Instrument", 80);
            listView_alltrade.Columns.Add("Inst type", 70);
            listView_alltrade.Columns.Add("Trade price", 80);
            listView_alltrade.Columns.Add("Market price", 85);
            listView_alltrade.Columns.Add("P&L", 60);
            listView_alltrade.Columns.Add("Delta", 60);
            listView_alltrade.Columns.Add("Gamma", 60);
            listView_alltrade.Columns.Add("Vega", 60);
            listView_alltrade.Columns.Add("Theta", 60);
            listView_alltrade.Columns.Add("Rho", 60);
        }
        private void generateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generatedata generateData = new Generatedata();
            generateData.ShowDialog();
        }
        private void instrumentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInstrType newInstrType = new NewInstrType();
            newInstrType.ShowDialog();
        }
        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInstrument newInstrument = new NewInstrument();
            newInstrument.ShowDialog();
        }
        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrade newTrade = new NewTrade();
            newTrade.ShowDialog();
        }
        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInterstRate newInterstRate = new NewInterstRate();
            newInterstRate.ShowDialog();
        }
        private void historicalPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHistoricalPrice newHistoricalPrice = new NewHistoricalPrice();
            newHistoricalPrice.ShowDialog();
        }
        public void refreshTradesFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView_alltrade.Items.Clear();
            ListViewItem listViewItem;
            var list = Program.PMC.Trades.ToList();
            foreach (var i in list)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = Convert.ToString(i.TradeID);
                if ((bool)i.IsBuy)
                    listViewItem.SubItems.Add("BUY");
                else
                    listViewItem.SubItems.Add("SELL");
                listViewItem.SubItems.Add(Convert.ToString(i.Quantity));
                listViewItem.SubItems.Add(i.Instrument.Ticker);
                listViewItem.SubItems.Add(i.Instrument.InstType.Typename);
                listViewItem.SubItems.Add(Convert.ToString(i.Price));
                listView_alltrade.Items.Add(listViewItem);
            }
        }
        private void priceBookUsingSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double vol = Convert.ToDouble(textBox_vol.Text) / 100;
            var query = from i in Program.PMC.StockPrices select i;
            //if no rates
            if ((from i in Program.PMC.InterestRates select i.Rate).Count() < 1)
                MessageBox.Show("Please add more interest rate!");
            else
            {
                // if the prices is not enough
                if ((query.Count() == 0) || (query.Count() < (from i in Program.PMC.Instruments where i.InstType.Typename == "Stock" select i).Count()))
                    MessageBox.Show("Please add more historical prices!");
                else
                {
                    listView_alltrade.BeginUpdate();
                    foreach (ListViewItem i in listView_alltrade.Items)
                    {
                        int id = Convert.ToInt32(i.SubItems[0].Text);
                        Trade trade = Program.PMC.Trades.SingleOrDefault(j => j.TradeID == id);
                        if (id > 0)
                        {
                            int direction;
                            if (i.SubItems[1].Text == "BUY")
                                direction = 1;
                            else
                                direction = -1;
                            int quantity = Convert.ToInt32(i.SubItems[2].Text);
                            string instrument = i.SubItems[3].Text;
                            string instrtype = i.SubItems[4].Text;
                            double marketprice = Convert.ToDouble(i.SubItems[5].Text);
                            //get the id of instrument
                            int Instid = Getdata.InstrumentID(instrument);
                            Instrument instrument1 = Getdata.instrument(Instid);
                            double S = Getdata.S(id);
                            double K = Getdata.strike(Instid);
                            double t = Getdata.tenor(Instid);
                            double r = Getdata.rate(t, Instid);
                            double rebate = Convert.ToDouble(instrument1.Rebate);
                            double barrier = Convert.ToDouble(instrument1.Barrier);
                            int barriertype = 0;
                            if (instrument1.BarrierType == "Down and out")
                                barriertype = 1;
                            if (instrument1.BarrierType == "Up and out")
                                barriertype = 2;
                            if (instrument1.BarrierType == "Down and in")
                                barriertype = 3;
                            if (instrument1.BarrierType == "Up and in")
                                barriertype = 4;
                            int optiontype = 0;
                            if (instrtype == "Stock")
                                optiontype = 0;
                            if (instrtype == "EuropeanOption")
                                optiontype = 1;
                            if (instrtype == "AsianOption")
                                optiontype = 2;
                            if (instrtype == "DigitalOption")
                                optiontype = 3;
                            if (instrtype == "BarrierOption")
                                optiontype = 4;
                            if (instrtype == "LookbackOption")
                                optiontype = 5;
                            if (instrtype == "RangeOption")
                                optiontype = 6;
                            bool Iscall;
                            if (instrument1.IsCall == true)
                                Iscall = true;
                            else
                                Iscall = false;
                            if (optiontype == 0)
                            {
                                //stock
                                //market price
                                i.SubItems.Add(Convert.ToString(S));
                                //P&L
                                i.SubItems.Add(((S - marketprice) * direction * quantity).ToString());
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity));
                                //gamma
                                i.SubItems.Add(Convert.ToString(0));
                                //vega
                                i.SubItems.Add(Convert.ToString(0));
                                //rho
                                i.SubItems.Add(Convert.ToString(0));
                                //theta
                                i.SubItems.Add(Convert.ToString(0));
                            }
                            //European
                            if (optiontype == 1)
                            {
                                //option
                                ExoticOption.Option European = new ExoticOption.EuropeanOption(S, K, r, vol, t, 10000, 100, Iscall, true, false, true);
                                //market price
                                i.SubItems.Add(Convert.ToString(European.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((European.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Rho()));
                            }
                            //Asian
                            if (optiontype == 2)
                            {
                                //option
                                ExoticOption.Option AisanOption = new ExoticOption.Asian(S, K, r, vol, t, 10000, 100, Iscall, true, false, true);
                                //market price
                                i.SubItems.Add(Convert.ToString(AisanOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((AisanOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Rho()));
                            }
                            //Digital
                            if (optiontype == 3)
                            {
                                //option
                                ExoticOption.Option DigitalOption = new ExoticOption.Digital(S, K, r, vol, t, 10000, 100, Iscall, true, false, true, rebate);
                                //market price
                                i.SubItems.Add(Convert.ToString(DigitalOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((DigitalOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Rho()));
                            }
                            //Barrier
                            if (optiontype == 4)
                            {
                                //option
                                ExoticOption.Option BarrierOption = new ExoticOption.Barrier(S, K, r, vol, t, 10000, 100, Iscall, true, false, true, 0, barrier, barriertype);
                                //market price
                                i.SubItems.Add(Convert.ToString(BarrierOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((BarrierOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Rho()));
                            }
                            //Lookback
                            if (optiontype == 5)
                            {
                                //option
                                ExoticOption.Option LookbackOption = new ExoticOption.Lookback(S, K, r, vol, t, 10000, 100, Iscall, true, false, true);
                                //market price
                                i.SubItems.Add(Convert.ToString(LookbackOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((LookbackOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Rho()));
                            }
                            //Range
                            if (optiontype == 6)
                            {
                                //option
                                ExoticOption.Option RangeOption = new ExoticOption.Range(S, K, r, vol, t, 10000, 100, Iscall, true, false, true);
                                //market price
                                i.SubItems.Add(Convert.ToString(RangeOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((RangeOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Rho()));
                            }
                        }
                    }
                }
            }
            listView_alltrade.EndUpdate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void historicalPriceAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoricalPriceAnalysis hisPriceAnalysis = new HistoricalPriceAnalysis();
            hisPriceAnalysis.ShowDialog();
        }
        private void interestRateAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RateAnalysis rateAnalysis = new RateAnalysis();
            rateAnalysis.ShowDialog();
        }
        private void listView_alltrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            //market price MP
            double MP = 0, Delta = 0, Gamma = 0, Vega = 0, Theta = 0, Rho = 0;
            foreach (ListViewItem i in listView_alltrade.SelectedItems)
            {
                if (i.SubItems.Count > 7)
                {
                    MP = MP + Convert.ToDouble(i.SubItems[7].Text);
                    Delta = Delta + Convert.ToDouble(i.SubItems[8].Text);
                    Gamma = Gamma + Convert.ToDouble(i.SubItems[9].Text);
                    Vega = Vega + Convert.ToDouble(i.SubItems[10].Text);
                    Theta = Theta + Convert.ToDouble(i.SubItems[11].Text);
                    Rho = Rho + Convert.ToDouble(i.SubItems[12].Text);
                }
            }
            ListViewItem listViewItem = new ListViewItem(MP.ToString());
            listViewItem.SubItems.Add(Convert.ToString(Delta));
            listViewItem.SubItems.Add(Convert.ToString(Gamma));
            listViewItem.SubItems.Add(Convert.ToString(Vega));
            listViewItem.SubItems.Add(Convert.ToString(Theta));
            listViewItem.SubItems.Add(Convert.ToString(Rho));
            listView_Total.BeginUpdate();
            listView_Total.Items.Clear();
            listView_Total.Items.Add(listViewItem);
            listView_Total.EndUpdate();
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView_alltrade.SelectedItems)
            {
                listView_alltrade.Items.Remove(i);
                Program.PMC.Trades.Remove((from j in Program.PMC.Trades where j.TradeID.ToString() == i.Text select j).FirstOrDefault());
                Program.PMC.SaveChanges();
            }
        }
        private void listView_alltrade_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_alltrade.FocusedItem.Bounds.Contains(e.Location))
                    contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
