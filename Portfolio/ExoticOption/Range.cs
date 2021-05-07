﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticOption
{
    public class Range:Option
    {
        public Range(double s, double k, double r, double sigma, double t, int trials, int steps, bool type, bool ant, bool cv, bool mt)
           : base(s, k, r, sigma, t, trials, steps, type, ant, cv, mt,0,0,0)
        {
            S = s;
            K = k;
            Mu = r;
            Sigma = sigma;
            T = t;
            Sims = trials;
            Steps = steps;
            IsCall = type;
            Ant = ant;
            CV = cv;
            MT = mt;
            RandomNumber random = new RandomNumber();
            if (MT == true)
                Epsilon = random.Increment(Sims, Steps);
            else
                Epsilon = random.rn(Sims, Steps);
        }
        public override double[] OptionPrice()
        {
            //sum1 means the sum of the pair of optionprice
            double sum1 = 0;
            double optionprice = 0;// means option price
            double stderror = 0;
            double[] result = new double[3];
            int core = 0;
            if (MT == true)
                core = System.Environment.ProcessorCount;
            else
                core = 1;
            //allsims store the price of each step
            if (Ant == true)//choose Ant Var
            {
                //allsims store the price of each step
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K,Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);

                if (CV == true)//choose CV
                {
                    double[] CT = new double[2 * Sims];
                    for (int i = 0; i < 2 * Sims; i++)
                    {
                        double cv = 0;
                        for (int j = 0; j < Steps; j++)
                        {
                            double delta = BSDelta(allsims[i, j], K, Mu, Sigma, T - j * T / Steps, IsCall);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Mu * (T / Steps)));
                        }
                        CT[i] = (maxnumber(allsims, i) - minnumber(allsims, i)) * Math.Exp(-Mu * T);
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(Option.std( 2 * Sims,CT) / (2 * Sims));
                }
                else//not choose CV
                {
                    double[] value = new double[2 * Sims];
                    for (int i = 0; i < Sims; i++)
                    {
                        value[i] = maxnumber(allsims, i) - minnumber(allsims, i);
                        value[i + Sims] = maxnumber(allsims, i + Sims) - minnumber(allsims, i + Sims);
                        sum1 += value[i];
                    }
                    //calculate option price
                    optionprice = sum1 / Sims * Math.Exp(-Mu * T);
                    double[] C = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        C[i] = (value[i] * Math.Exp(-Mu * T) + value[i + Sims] * Math.Exp(-Mu * T)) / 2;
                    stderror = Math.Sqrt(Option.std(Sims,C) / Sims);
                }
                result[0] = optionprice;
                result[1] = stderror;
                result[2] = core;
            }
            else//not Ant
            {
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
                if (CV == true)//choose CV
                {
                    double[] CT = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                    {
                        double cv = 0;
                        for (int j = 0; j < Steps; j++)
                        {
                            double delta = BSDelta(allsims[i, j], K, Mu, Sigma, T - j * T / Steps, IsCall);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Mu * (T / Steps)));
                        }
                        CT[i] = (maxnumber(allsims, i) - minnumber(allsims, i)) * Math.Exp(-Mu * T);
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(Option.std( Sims,CT) / Sims);
                }
                else//not choose CV
                {
                    double[] value = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        value[i] = (maxnumber(allsims, i) - minnumber(allsims, i)) * Math.Exp(-Mu * T);
                    //calculate option price
                    optionprice = value.Average();
                    stderror = Math.Sqrt(Option.std(Sims, value) / Sims);
                }
                result[0] = optionprice;
                result[1] = stderror;
                result[2] = core;
            }
            return result;
        }
    }
}
