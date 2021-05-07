using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticOption
{
    public class Asian : Option
    {
        public Asian(double s, double k, double r, double sigma, double t, int trials, int steps, bool type, bool ant, bool cv, bool mt)
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
        public override double[] OptionPrice()//double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, bool MT)//, double[,] Epsilon)
        {
            double optionprice = 0;
            double se = 0;
            int core = 0;
            double[] result = new double[3];
            int beta1 = -1;
            if (MT == true)
                core = System.Environment.ProcessorCount;
            else
                core = 1;

            if (Ant == true)
            {
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
                double[] AveragePrice = new double[2 * Sims]; //it just need the average value of the simulation
                for (int i = 0; i < 2 * Sims; i++)
                {
                    double SumPrice = 0;
                    for (int j = 0; j < Steps + 1; j++)
                    {
                        SumPrice += allsims[i, j];
                    }
                    AveragePrice[i] = SumPrice / (Steps + 1);
                }

                if (CV == true)
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
                            CT[i] = (Math.Max(AveragePrice[i] - K, 0) + beta1 * cv) * Math.Exp(-Mu * T);
                        }
                        else //Put
                        {
                            CT[i] = (Math.Max(K - AveragePrice[i], 0) + beta1 * cv) * Math.Exp(-Mu * T);
                        }
                    }
                    optionprice = CT.Average();
                    double[] C = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        C[i] = (CT[i] + CT[i + Sims]) / 2;
                    se = Math.Sqrt(std(Sims, C) / (Sims));
                }
                else //not choose CV
                {
                    double[] value = new double[2 * Sims];
                    double sum = 0;
                    if (IsCall == true)
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = Math.Max(AveragePrice[i] - K, 0) * Math.Exp(-Mu * T);
                            value[i + Sims] = Math.Max(AveragePrice[i+Sims] - K, 0) * Math.Exp(-Mu * T);
                            sum += value[i];
                        }
                    }
                    else //Put
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = Math.Max(K - AveragePrice[i], 0) * Math.Exp(-Mu * T);
                            value[i + Sims] = Math.Max(K - allsims[i + Sims, Steps], 0) * Math.Exp(-Mu * T);
                            sum += value[i];
                        }
                    }
                    //calculate option price
                    optionprice = value.Average();
                    double[] C = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        C[i] = (value[i] + value[i + Sims]) / 2;
                    se = Math.Sqrt(std(Sims, C) / Sims);
                }
                //store them to a matrix
                result[0] = optionprice;
                result[1] = se;
                result[2] = core;
            }

            else//not Ant Var
            {
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
                double[] AveragePrice = new double[2 * Sims];
                for (int i = 0; i < Sims; i++)
                {
                    double SumPrice = 0;
                    for (int j = 0; j < Steps + 1; j++)
                    {
                        SumPrice += allsims[i, j];
                    }
                    AveragePrice[i] = SumPrice / (Steps + 1);
                }
                if (CV == true)
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
                            CT[i] = (Math.Max(AveragePrice[i] - K, 0) + beta1 * cv) * Math.Exp(-Mu * T);
                        else
                            CT[i] = (Math.Max(K - AveragePrice[i], 0) + beta1 * cv) * Math.Exp(-Mu * T);
                    }
                    optionprice = CT.Average();
                    se = Math.Sqrt(std(Sims, CT) / Sims);
                }
                else //not CV
                {
                    double[] value = new double[Sims];
                    if (IsCall == true)
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = Math.Max(AveragePrice[i] - K, 0) * Math.Exp(-Mu * T);
                    }
                    else
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = Math.Max(K - AveragePrice[i], 0) * Math.Exp(-Mu * T);
                    }
                    //calculate option price
                    optionprice = value.Average();
                    se = Math.Sqrt(std(Sims, value) / Sims);
                }

                //return core;
                result[0] = optionprice;
                result[1] = se;
                result[2] = core;
            }
            // OptionPrice()[0] = result[0];
            return result;
        }
        //private double p2;
      

    }
}
