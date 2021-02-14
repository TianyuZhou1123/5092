using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls.Ribbon;

namespace MonteC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //S means underlying price
            double S = Convert.ToDouble(textBox_S.Text);
            //K means Strike price
            double K = Convert.ToDouble(textBox_K.Text);
            //r means the Risk-free rate
            double r = Convert.ToDouble(textBox_R.Text);
            //Sigma means Volatility
            double Sigma = Convert.ToDouble(textBox_Sigma.Text);
            //T means Tenor
            double T = Convert.ToDouble(textBox_T.Text);
            //Trials means the trials of Mento Carlo Simulations
            int Trials = Convert.ToInt32(textBox_Trials.Text);
            //steps means the steps to calculate the option price
            int steps = Convert.ToInt32(textBox_Steps.Text);
            EuropeanOption Option = new EuropeanOption();
            RandomNumber epsilon = new RandomNumber();
            //input the values of European Option
            Option.S = S;
            Option.K = K;
            Option.Mu = r;//Risk-free rate
            Option.Sigma = Sigma;
            Option.T = T;
            Option.Sims = Trials;
            Option.Steps = steps;
            double[,] RandomNumber = epsilon.Epsilon(Trials, steps);
            Option.Epsilon = RandomNumber;
            //set the type 
            if (IsCall.Checked == true)
                Option.IsCall = true;
            else
                Option.IsCall = false;
            textBox_OptionPrice.Text = Convert.ToString(EuropeanOption.OptionPrice(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber)[0]);
            textBox_Std.Text = Convert.ToString(EuropeanOption.OptionPrice(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber)[1]);
            textBox_Delta.Text = Convert.ToString(GreekValues.Delta(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber));
            textBox_Gamma.Text = Convert.ToString(GreekValues.Gamma(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber));
            textBox_Vega.Text = Convert.ToString(GreekValues.Vega(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber));
            textBox_Theta.Text = Convert.ToString(GreekValues.Theta(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber));
            textBox_Rho.Text = Convert.ToString(GreekValues.Rho(S, K, r, Sigma, T, Trials, steps, IsCall.Checked, RandomNumber));
        }
    }
}
