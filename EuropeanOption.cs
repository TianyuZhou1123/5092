﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteC
{
    class EuropeanOption
    {
        private double s, k, r, sigma, t;
        private int trials, steps;
        private bool type;
        private double[,] randomnumber;
        public double S { get { return s; } set { s = value; } }
        //S means UnderlyingPrice
        public double K { get { return k; } set { k = value; } }
        //K means StrikePprice
        public double Mu { get { return r; } set { r = value; } }
        //Rate means Interesting rate
        public double Sigma { get { return sigma; } set { sigma = value; } }
        //Sigma means Volitility
        public double T { get { return t; } set { t = value; } }
        //Tenor means the time to hold
        public int Sims { get { return trials; } set { trials = value; } }
        //Sims means the trials of Matro Carlo Simulations
        public int Steps { get { return steps; } set { steps = value; } }
        //Steps means the steps to calculate the MontePrice
        public bool IsCall { get { return type; } set { type = value; } }
        //IsCall means to judge if it is a call option
        public double[,] Epsilon { get { return randomnumber; } set { randomnumber = value; } }
        //Epsilon means generate the random numbers
        public static double []OptionPrice(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double[,] allsims = new double[Sims, Steps + 1];
            //store the prices of every steps
            for (int i = 0; i < Sims; i++)
            {
                allsims[i, 0] = S;
                //let the first column be S
            }
            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    allsims[i, j + 1] = allsims[i, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) + Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                }
            }
            double[] value = new double[Sims];
            if (IsCall == true)//call
            {
                for (int i = 0; i < Sims; i++)
                {
                    value[i] = Math.Max(allsims[i, Steps] - K, 0);
                }
            }
            else//put
            {
                for (int i = 0; i < Sims; i++)
                {
                    value[i] = Math.Max(K - allsims[i, Steps], 0);
                }
            }//calculate the option price in the last column
            double optionprice = value.Sum() / Sims * Math.Exp(-Mu * T);
            //calculate the option price
            double[] C = new double[Sims];
            for (int i = 0; i < Sims; i++)
                C[i] = value[i] * Math.Exp(-Mu * T);
            double sd = EuropeanOption.std(C, Sims);
            double[] result = { optionprice, sd };
            return result;
        }
        public static double std(double[] C, int Sims)
        {
            //the average of matrix C
            double C0 = C.Average();
            double[] sum = new double[Sims];
            for (int i = 0; i < Sims; i++)
                sum[i] = (C[i] - C0) * (C[i] - C0);
            //calculate std
            double sd = Math.Sqrt((sum.Sum()) / (Sims - 1));
            return sd;
        }
    }
}
