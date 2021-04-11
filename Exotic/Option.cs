using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticOption
{
    public abstract class Option
    {
        private double s, k, r, sigma, t,rebate,barrier;
        private int trials, steps,barriertype;
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
        public double[,] Epsilon { get { return randomnumber; } set { randomnumber = value; } }
        public double Rebate { get { return rebate; } set { rebate = value; } }
        public double Barrier { get { return barrier; } set { barrier = value; } }
        public int Barriertype { get { return barriertype; } set { barriertype = value; } }
        //Epsilon means generate the random numbers
        //public EuropeanOption(double s, double k, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, bool MT)
        public Option(double S, double K, double Mu, double Sigma, double T, int Trials, int Steps, bool Type, bool Ant, bool CV, bool MT, double Rebate, double Barrier, int Barriertype)
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
            Barrier = barrier;
            Rebate = rebate;
            Barriertype = barriertype;
            RandomNumber random = new RandomNumber();
            // random.Sims = Sims;
            // random.Steps = Steps;
            //Epsilon = random.rn();
            if (MT == true)
                Epsilon = random.Increment(Sims, Steps);
            else
                Epsilon = random.rn(Sims, Steps);
        }
        public abstract double [] OptionPrice();
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
        public static double maxnumber(double[,] matrix, int row_num)
        {
            double maximum = matrix[row_num, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
                maximum = Math.Max(maximum, matrix[row_num, j]);
            return maximum;
        }
        public static double minnumber(double[,] matrix, int row_num)
        {
            double minimum = matrix[row_num, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
                minimum = Math.Min(minimum, matrix[row_num, j]);
            return minimum;
        }
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
 
        public double Vega()
        {
            double ori = Sigma;
            Sigma = 1.001 * ori;
            double op1 = OptionPrice()[0];
            Sigma = 0.999 * ori;
            double op2 = OptionPrice()[0];
            Sigma = ori;
            double vega = (op1 - op2) / (0.002 * Sigma);
            return vega;
        }

        public double Theta()
        {
            double ori = T;
            T = 1.001 * ori;
            double op1 = OptionPrice()[0];
            T = ori;
            double op2 = OptionPrice()[0];
            double theta = (-1) * (op1 - op2) / (0.001 * T);
            return theta;
        }

        public double Rho()
        {
            double ori = Mu;
            Mu = 1.001 * ori;
            double op1 = OptionPrice()[0];
            Mu = 0.999 * ori;
            double op2 = OptionPrice()[0];
            Mu = ori;
            double rho = (op1 - op2) / (0.002 * Mu);
            return rho;
        }
    }
}
