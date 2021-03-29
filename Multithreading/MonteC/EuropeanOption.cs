using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteC
{
    public class EuropeanOption
    {
         
        private double s, k, r, sigma, t;
        private int trials, steps;
        private bool type, ant, cv, mt;
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
        public bool Ant { get { return ant; } set { ant = value; } }
        //Ant means if we should use antithetic variation reduction
        public bool CV { get { return cv; } set { cv = value; } }
        //CV means cotrol variance
        public bool MT { get { return mt; } set { mt = value; } }
        protected double[,] Epsilon { get { return randomnumber; } set { randomnumber = value; } }
        //{ get { return randomnumber; } set { randomnumber = value; } }
        //Epsilon means generate the random numbers
        //public EuropeanOption(double s, double k, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, bool MT)
        public EuropeanOption(double s, double k, double r, double sigma, double t, int trials, int steps, bool type, bool ant, bool cv, bool mt)
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
            // random.Sims = Sims;
            // random.Steps = Steps;
            //Epsilon = random.rn();
            if (MT == true)
                Epsilon = random.Increment(Sims, Steps);
            else
                Epsilon = random.rn(Sims, Steps);

        }
        public static double std(int Sims, double[] Price) //calculate se
        {
            double P = Price.Average();
            double[] sum = new double[Sims];
            for (int i = 0; i < Sims; i++)
            {
                sum[i] = (Price[i] - P) * (Price[i] - P);
            }
            double sdsquared = (sum.Sum()) / (Sims - 1);//Price1 Price2 are identically distributed, so their Var are the same
            return sdsquared;
        }
        public static double BSDelta(double S, double K, double r, double Sigma, double T, bool IsCall)
        {
            double d1 = (Math.Log(S / K) + (r + 0.5 * Math.Pow(Sigma, 2)) * T) / (Sigma * Math.Sqrt(T));
            if (IsCall == true)
                return cdf(d1);
            else
                return cdf(d1) - 1;
        }
        public int cores_num()
        {
            int core;
            if (MT == true)
                core = System.Environment.ProcessorCount;
            else
                core = 1;
            return core;
        }

        public virtual double[] OptionPrice()//double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, bool MT)//, double[,] Epsilon)
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
                            CT[i] = (Math.Max(allsims[i, Steps] - K, 0) + beta1 * cv) * Math.Exp(-Mu * T);
                        }
                        else //Put
                        {
                            CT[i] = (Math.Max(K - allsims[i, Steps], 0) + beta1 * cv) * Math.Exp(-Mu * T);
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
                            value[i] = Math.Max(allsims[i, Steps] - K, 0) * Math.Exp(-Mu * T);
                            value[i + Sims] = Math.Max(allsims[i + Sims, Steps] - K, 0) * Math.Exp(-Mu * T);
                            sum += value[i];
                        }
                    }
                    else //Put
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = Math.Max(K - allsims[i, Steps], 0) * Math.Exp(-Mu * T);
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
                result[2] = core ;
            }

            else//not Ant Var
            {
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, MT, Epsilon);
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
                            CT[i] = (Math.Max(allsims[i, Steps] - K, 0) + beta1 * cv) * Math.Exp(-Mu * T);
                        else
                            CT[i] = (Math.Max(K - allsims[i, Steps], 0) + beta1 * cv) * Math.Exp(-Mu * T);
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
                            value[i] = Math.Max(allsims[i, Steps] - K, 0) * Math.Exp(-Mu * T);
                    }
                    else
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = Math.Max(K - allsims[i, Steps], 0) * Math.Exp(-Mu * T);
                    }
                    //calculate option price
                    optionprice = value.Average();
                    se = Math.Sqrt(std(Sims, value) / Sims);
                }

                //return core;
                result[0] = optionprice;
                result[1] = se;
                result[2] = core ;
            }
           // OptionPrice()[0] = result[0];
            return result;
        }




        private double p2;
        public double Delta()
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice()[0];
            S = 0.999 * ori;
            double op2 = OptionPrice()[0];
            S = ori;
            double delta = (op1 - op2) / (0.002 * S);
            return delta;
        }
        //Gamma
        public double Gamma()
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice()[0];
            S = ori;
            double op2 = OptionPrice()[0];
            S = 0.999 * ori;
            double op3 = OptionPrice()[0];
            S = ori;
            double gamma = (op1 - 2 * op2 + op3) / (Math.Pow((0.001 * ori), 2));
            return gamma;
        }
        //Vega
        public double Vega()
        {
            double ori = Sigma;
            Sigma = 1.1 * ori;
            double op1 = OptionPrice()[0];
            Sigma = 0.9 * ori;
            double op2 = OptionPrice()[0];
            Sigma = ori;
            double vega = (op1 - op2) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public double Theta()
        {
            double ori = T;
            T = 1.1 * ori;
            double op1 = OptionPrice()[0];
            T = ori;
            double op2 = OptionPrice()[0];
            double theta = (-1) * (op1 - op2) / (0.1 * T);
            return theta;
        }
        //Rho
        public double Rho()
        {
            double ori = Mu;
            Mu = 1.1 * ori;
            double op1 = OptionPrice()[0];
            Mu = 0.9 * ori;
            double op2 = OptionPrice()[0];
            Mu = ori;
            double rho = (op1 - op2) / (0.2 * Mu);
            return rho;
        }
        public static double cdf(double x)
        {
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            double sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * y);
        }

    }
}
