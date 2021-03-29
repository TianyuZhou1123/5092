using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MonteC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void ThreadStart();
        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (textBox_S.Text == String.Empty || textBox_K.Text == String.Empty || textBox_R.Text == String.Empty || textBox_Sigma.Text == String.Empty || textBox_T.Text == String.Empty || textBox_Trials.Text == String.Empty || textBox_Steps.Text == String.Empty)
                MessageBox.Show("Missing some inputs");
            else
            {
                // Initialize time
                Control.CheckForIllegalCrossThreadCalls = false;
                Stopwatch watch = new Stopwatch();
                watch.Reset();
                watch.Start();
                Option();
                watch.Stop();
                textBox_time.Text = watch.Elapsed.Hours.ToString() + ":" + watch.Elapsed.Minutes.ToString() + ":" + watch.Elapsed.Seconds.ToString() + ":" + watch.Elapsed.Milliseconds.ToString();
            }
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

        private void cores_num()
        {
            int core;
            if (MT.Checked == true)
                core = System.Environment.ProcessorCount;
            else
                core = 1;
            number(core);
        }
        private void number(int result)
        {
            label_bar.Text = Convert.ToString(result);
        }



        public EuropeanOption OptionV = null;
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
            bool cv = Convert.ToBoolean(CV.Checked);
            bool iscall = Convert.ToBoolean(IsCall.Checked);
            bool ant = Convert.ToBoolean(Ant.Checked);
            bool mt = Convert.ToBoolean(MT.Checked);
            RandomNumber epsilon = new RandomNumber();


            if (mt)
            {
                Task.Run(() =>
                {
                    //Asynchronous thread 4 thread
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
                });

                Task.Run(OptionPrice3);
                Task.Run(Rho);
            }
            else
            {

                //synchronous thread
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


        }


        public void OptionPrice1()
        {
            textBox_OptionPrice.Text = Convert.ToString(OptionV.OptionPrice()[0]);
        }

        public void OptionPrice2()
        {
            textBox_Std.Text = Convert.ToString(OptionV.OptionPrice()[1]);
        }

        public void Delta()
        {
            textBox_Delta.Text = Convert.ToString(OptionV.Delta());
        }
        public void Gamma()
        {
            textBox_Gamma.Text = Convert.ToString(OptionV.Gamma());
        }

        public void Vega()
        {
            textBox_Vega.Text = Convert.ToString(OptionV.Vega());
        }

        public void Theta()
        {
            textBox_Theta.Text = Convert.ToString(OptionV.Theta());
        }

        public void OptionPrice3()
        {
            label_bar.Text = Convert.ToString(OptionV.OptionPrice()[2]);
        }

        public void Rho()
        {
            textBox_Rho.Text = Convert.ToString(OptionV.Rho());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

