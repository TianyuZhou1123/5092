using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ExoticOption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Option();
            watch.Stop();
            textBox_time.Text = watch.Elapsed.Hours.ToString() + ":" + watch.Elapsed.Minutes.ToString() + ":" + watch.Elapsed.Seconds.ToString() + ":" + watch.Elapsed.Milliseconds.ToString();
        }
        public void inprogress(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(inprogress), new object[] { i });
                return;
            }
            progressBar1.Value = i;
        }
        public EuropeanOption OptionV = null;
        public Asian OptionV1 = null;
        public Digital OptionV2 = null;
        public Barrier OptionV3 = null;
        public Lookback OptionV4 = null;
        public Range OptionV5 = null;
        private void Option()
        {
            double S = Convert.ToDouble(textBox_S.Text);
            //K means strike price
            double K = Convert.ToDouble(textBox_K.Text);
            //r means the interest rate
            double r = Convert.ToDouble(textBox_R.Text);
            //Sigma means volatility
            double Sigma = Convert.ToDouble(textBox_Sigma.Text);
            //T means tenor
            double T = Convert.ToDouble(textBox_T.Text);
            //Trials means the trials of Mento Carlo Simulations
            int Trials = Convert.ToInt32(textBox_Trials.Text);
            //steps means the steps to calculate the option price
            int steps = Convert.ToInt32(textBox_Steps.Text);
            bool ant = Convert.ToBoolean(checkBox_Ant.Checked);
            bool iscall = Convert.ToBoolean(checkBox_IsCall.Checked);
            bool mt = Convert.ToBoolean(checkBox_MT.Checked);
            bool cv = Convert.ToBoolean(checkBox_CV.Checked);
            RandomNumber epsilon = new RandomNumber();
            if (mt)//Asynchronous method 
            {
                Task.Run(() =>
                {
                    if(EuropeanOption.Checked)
                    {
                        OptionV = new EuropeanOption(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                        inprogress(20);
                        var a = OptionV.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV.Theta());
                        label_bar.Text = Convert.ToString(a[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV.Rho());
                        inprogress(100);
                    }
                    else if(Asian.Checked)
                    {
                        OptionV1 = new Asian(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                        inprogress(20);
                        var a = OptionV1.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV1.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV1.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV1.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV1.Theta());
                        label_bar.Text = Convert.ToString(OptionV1.OptionPrice()[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV1.Rho());
                        inprogress(100);
                    }
                    else if(Digital.Checked)
                    {
                        textBox_Rebate.Enabled = true;
                        double Rebate = Convert.ToDouble(textBox_Rebate.Text);
                        OptionV2 = new Digital(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt,Rebate);
                        inprogress(20);
                        var a = OptionV2.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV2.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV2.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV2.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV2.Theta());
                        label_bar.Text = Convert.ToString(a[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV2.Rho());
                        inprogress(100);
                    }
                    else if(checkBox_Barrier.Checked)
                    {
                        double Rebate = Convert.ToDouble(textBox_Rebate.Text);
                        double Barrier = Convert.ToDouble(textBox_Barrier.Text);
                        int Barriertype = Convert.ToInt32(comboBox1.SelectedIndex);
                        //int Barriertype = Convert.ToInt32(textBox_Barriertype.Text);
                        OptionV3 = new Barrier(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt,Rebate,Barrier,Barriertype);
                        inprogress(20);
                        var a = OptionV3.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV3.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV3.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV3.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV3.Theta());
                        label_bar.Text = Convert.ToString(OptionV3.OptionPrice()[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV3.Rho());
                        inprogress(100);
                    }
                    else if(LookBack.Checked)
                    {
                        OptionV4 = new Lookback(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                        inprogress(20);
                        var a = OptionV4.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV4.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV4.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV4.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV4.Theta());
                        label_bar.Text = Convert.ToString(OptionV4.OptionPrice()[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV4.Rho());
                        inprogress(100);
                    }
                    else if(Range.Checked)
                    {
                        OptionV5 = new Range(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                        inprogress(20);
                        var a = OptionV5.OptionPrice();
                        textBox_OptionPrice.Text = Convert.ToString(a[0]);
                        inprogress(30);
                        textBox_Std.Text = Convert.ToString(a[1]);
                        inprogress(40);
                        textBox_Delta.Text = Convert.ToString(OptionV5.Delta());
                        inprogress(50);
                        textBox_Gamma.Text = Convert.ToString(OptionV5.Gamma());
                        inprogress(60);
                        textBox_Vega.Text = Convert.ToString(OptionV5.Vega());
                        inprogress(70);
                        textBox_Theta.Text = Convert.ToString(OptionV5.Theta());
                        label_bar.Text = Convert.ToString(OptionV5.OptionPrice()[2]);
                        textBox_Rho.Text = Convert.ToString(OptionV5.Rho());
                        inprogress(100);
                    }
                });
            }
            else//Synchronous method 
            {
                if (EuropeanOption.Checked)
                {
                    OptionV = new EuropeanOption(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                    inprogress(20);
                    var a = OptionV.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV.Theta());
                    label_bar.Text = Convert.ToString(OptionV.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV.Rho());
                    inprogress(100);
                }
                else if (Asian.Checked)
                {
                    OptionV1 = new Asian(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                    inprogress(20);
                    var a = OptionV1.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV1.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV1.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV1.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV1.Theta());
                    label_bar.Text = Convert.ToString(OptionV1.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV1.Rho());
                    inprogress(100);
                }
                else if (Digital.Checked)
                {
                    textBox_Rebate.Enabled = true;
                    double Rebate = Convert.ToDouble(textBox_Rebate.Text);
                    OptionV2 = new Digital(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt, Rebate);
                    inprogress(20);
                    var a = OptionV2.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV2.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV2.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV2.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV2.Theta());
                    label_bar.Text = Convert.ToString(OptionV2.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV2.Rho());
                    inprogress(100);
                }
                else if (checkBox_Barrier.Checked)
                {
                    double Barrier = Convert.ToDouble(textBox_Barrier.Text);
                    int Barriertype = Convert.ToInt32(comboBox1.SelectedIndex);
                    OptionV3 = new Barrier(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt, 0, Barrier, Barriertype);
                    inprogress(20);
                    var a = OptionV3.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV3.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV3.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV3.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV3.Theta());
                    label_bar.Text = Convert.ToString(OptionV3.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV3.Rho());
                    inprogress(100);
                }
                else if (LookBack.Checked)
                {
                    OptionV4 = new Lookback(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                    inprogress(20);
                    var a = OptionV4.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV4.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV4.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV4.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV4.Theta());
                    label_bar.Text = Convert.ToString(OptionV4.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV4.Rho());
                    inprogress(100);
                }
                else if (Range.Checked)
                {
                    OptionV5 = new Range(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
                    inprogress(20);
                    var a = OptionV5.OptionPrice();
                    textBox_OptionPrice.Text = Convert.ToString(a[0]);
                    inprogress(30);
                    textBox_Std.Text = Convert.ToString(a[1]);
                    inprogress(40);
                    textBox_Delta.Text = Convert.ToString(OptionV5.Delta());
                    inprogress(50);
                    textBox_Gamma.Text = Convert.ToString(OptionV5.Gamma());
                    inprogress(60);
                    textBox_Vega.Text = Convert.ToString(OptionV5.Vega());
                    inprogress(70);
                    textBox_Theta.Text = Convert.ToString(OptionV5.Theta());
                    label_bar.Text = Convert.ToString(OptionV5.OptionPrice()[2]);
                    textBox_Rho.Text = Convert.ToString(OptionV5.Rho());
                    inprogress(100);
                }
            }
        }
        private void Digital_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Rebate.Enabled = true;
        }

        private void checkBox_Barrier_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Barrier.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void LookBack_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Rebate.Enabled = false;
            textBox_Barrier.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void Range_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Rebate.Enabled = false;
            textBox_Barrier.Enabled = false;
            comboBox1.Enabled = false;
        }
    }
}
