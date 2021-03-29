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

        private void Option()
        {
            // inprogress(0);
            // Thread.Sleep(1000);
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
            //RandomNumber epsilon = new RandomNumber();
            EuropeanOption Option = new EuropeanOption(S, K, r, Sigma, T, Trials, steps, iscall, ant, cv, mt);
            inprogress(20);
     
            textBox_OptionPrice.Text = Convert.ToString(Option.OptionPrice()[0]);
            inprogress(30);
            textBox_Std.Text = Convert.ToString(Option.OptionPrice()[1]);
            inprogress(40);
         
            //delta
            textBox_Delta.Text = Convert.ToString(Option.Delta());
            inprogress(50);
            //gamma
            textBox_Gamma.Text = Convert.ToString(Option.Gamma());
            inprogress(60);
            //vega
            textBox_Vega.Text = Convert.ToString(Option.Vega());
            inprogress(70);
          
            //theta
            textBox_Theta.Text = Convert.ToString(Option.Theta());
            inprogress(80);
            label_bar.Text = Convert.ToString(Option.OptionPrice()[2]);
            inprogress(90);
            //rho
            textBox_Rho.Text = Convert.ToString(Option.Rho());
            inprogress(100);
        }
    }
}

