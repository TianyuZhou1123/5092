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
        private bool type, ant;
        private double[,] randomnumber;
        public double S { get { return s; } set { s = value; } }
        //S means UnderlyingPrice
        public double K { get { return k; } set { k = value; } }
        //K means StrikePprice
        public double Mu { get { return r; } set { r = value; } }
        //Rate means Risk-free rate
        public double Sigma { get { return sigma; } set { sigma = value; } }
        //Sigma means Volitility
        public double T { get { return t; } set { t = value; } }
        //T(Tenor) means the time to hold(year)
        public int Sims { get { return trials; } set { trials = value; } }
        //Sims means the trials of Matro Carlo Simulations
        public int Steps { get { return steps; } set { steps = value; } }
        //Steps means the steps to calculate the MontePrice
        public bool IsCall { get { return type; } set { type = value; } }
        //IsCall means to judge if it is a call option
        public bool Ant { get { return ant; }set { ant = value; } }
        //Ant means if we should use antithetic variation reduction
        public double[,] Epsilon { get { return randomnumber; } set { randomnumber = value; } }
        //Epsilon means generate the random numbers
        public static double std(int Sims, double[] Price) //calculate se
        {
            double P = Price.Average();
            double[] sum = new double[Sims];
            for (int i = 0; i < Sims; i++)
            {
                sum[i] = (Price[i]- P) * (Price[i] - P);
            }
            double sd = Math.Sqrt((sum.Sum()) / (Sims));//Price1 Price2 are identically distributed, so their Var are the same
            double se = sd / Math.Sqrt(Sims);
            return se;
        }
        public static double[] OptionPrice(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall,bool Ant, double[,] Epsilon)
        {
            if(Ant ==true)
            {
                double[,] allsims = new double[2 * Sims, Steps + 1];
                for(int i = 0; i<Sims; i++)
                {
                    allsims[i, 0] = S;
                    allsims[i + Sims, 0] = S;
                    for (int j = 0; j < Steps ; j++)
                    {
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) + Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                        allsims[i + Sims, j + 1] = allsims[i + Sims, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) - Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                    }
                }
                double[] value = new double[2*Sims];
                if (IsCall == true)
                {
                    for (int i = 0; i < 2 * Sims; i++)
                    {
                        value[i] = Math.Max(allsims[i, Steps] - K, 0);
                    }
                        
                }
                else
                {
                    for (int i = 0; i < 2 * Sims; i++)
                    {
                        value[i] = Math.Max(K - allsims[i, Steps], 0);
                    }
                }
                double optionprice = value.Average() * Math.Exp(-Mu * T);
                //calculate the option price in the beginning
                double[] Price = new double[Sims];
                for (int i = 0; i < Sims; i++)
                    Price[i] = 0.5 * (value[i] + value[i + Sims]) * Math.Exp(-Mu * T);
                double sd = EuropeanOption.std(Sims, Price);
                double[] result = { optionprice, sd };
                return result;
            }
            else
            {
                double[,] allsims = new double[Sims, Steps + 1];
                for (int i = 0; i < Sims; i++)
                {
                    allsims[i, 0] = S; //let the first column be S
                    for (int j = 0; j < Steps; j++)
                    {
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) + Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                    }
                }//store the prices of every steps
                double[] value = new double[Sims];
                if (IsCall == true)
                {
                    for (int i = 0; i < Sims; i++)
                    {
                        value[i] = Math.Max(allsims[i, Steps] - K, 0);//calculate the option price in the last column
                    }
                }
                else
                {
                    for (int i = 0; i < Sims; i++)
                    {
                        value[i] = Math.Max(K - allsims[i, Steps], 0);
                    }
                }
                double optionprice = value.Average() * Math.Exp(-Mu * T);
                //calculate the option price in the beginning
                double[] Price = new double[Sims];
                for (int i = 0; i < Sims; i++)
                    Price[i] = value[i] * Math.Exp(-Mu * T);
                double sd = EuropeanOption.std(Sims, Price);
                double[] result = { optionprice, sd };
                return result;
            }
            
            
 
        }
    }
}
