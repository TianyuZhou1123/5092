using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticOption
{
    public class Barrier:Option
    {
        public Barrier(double s, double k, double r, double sigma, double t, int trials, int steps, bool type, bool ant, bool cv, bool mt, double rebate, double barrier, int barriertype)
          : base(s, k, r, sigma, t, trials, steps, type, ant, cv, mt, rebate, barrier, barriertype)
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
            Rebate = rebate;
            Barriertype = barriertype;
            Barrier = barrier;
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
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
                //Barrier types
                double[] barrier_payoff = new double[2 * Sims];
                for (int i = 0; i < 2 * Sims; i++)
                {
                    //Down and out
                    if (Barriertype == 0)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Up and out 
                    if (Barriertype == 1)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Down and in
                    if (Barriertype == 2)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                    //Up and in
                    if (Barriertype == 3)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                }
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
                        if (IsCall == true)
                        {
                            CT[i] = barrier_payoff[i] * (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Mu * T);
                        }
                        else
                        {
                            CT[i] = barrier_payoff[i] * (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Mu * T);
                        }
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(std(2 * Sims,CT) / (2 * Sims));
                }
                else//not choose CV
                {
                    double[] value = new double[2 * Sims];
                    if (IsCall == true)//call
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = barrier_payoff[i] * Math.Max(allsims[i, Steps] - K, 0);
                            value[i + Sims] = barrier_payoff[i] * Math.Max(allsims[i + Sims, Steps] - K, 0);
                            sum1 += value[i];
                        }
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = barrier_payoff[i] * Math.Max(K - allsims[i, Steps], 0);
                            value[i + Sims] = barrier_payoff[i] * Math.Max(K - allsims[i + Sims, Steps], 0);
                            sum1 += value[i];
                        }
                    }
                    //calculate option price
                    optionprice = sum1 / Sims * Math.Exp(-Mu * T);
                    double[] C = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        C[i] = (value[i] * Math.Exp(-Mu * T) + value[i + Sims] * Math.Exp(-Mu * T)) / 2;
                    stderror = Math.Sqrt(std(Sims,C) / Sims);
                }
                //store the result into matrix result
                result[0] = optionprice;
                result[1] = stderror;
                result[2] = core;
            }
            else//not Ant
            {
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
                double[] barrier_payoff = new double[Sims];
                for (int i = 0; i < Sims; i++)
                {
                    //Down and out
                    if (Barriertype == 0)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Up and out 
                    if (Barriertype == 1)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Down and in
                    if (Barriertype == 2)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                    //Up and in
                    if (Barriertype == 3)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                }
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
                        if (IsCall == true)
                            CT[i] = barrier_payoff[i] * (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Mu * T);
                        else
                            CT[i] = barrier_payoff[i] * (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Mu * T);
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(std(Sims,CT) / Sims);
                }
                else//not choose CV
                {
                    double[] value = new double[Sims];
                    if (IsCall == true)//call
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = barrier_payoff[i] * Math.Max(allsims[i, Steps] - K, 0) * Math.Exp(-Mu * T);
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = barrier_payoff[i] * Math.Max(K - allsims[i, Steps], 0) * Math.Exp(-Mu * T);
                    }
                    //calculate option price
                    optionprice = value.Average();
                    stderror = Math.Sqrt(std( Sims,value) / Sims);
                }
                //store the result into matrix result
                result[0] = optionprice;
                result[1] = stderror;
                result[2] = core;
            }
            return result;
        }
    }
}
