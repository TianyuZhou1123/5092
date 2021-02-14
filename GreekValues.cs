using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteC
{
    class GreekValues
    {
        public static double Delta(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double delta = (EuropeanOption.OptionPrice(1.001 * S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0] - EuropeanOption.OptionPrice(0.999 * S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0]) / (0.002 * S);
            return delta;
        }
        //Gamma
        public static double Gamma(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double gamma = (EuropeanOption.OptionPrice(1.001 * S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0] - 2 * EuropeanOption.OptionPrice(S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0] + EuropeanOption.OptionPrice(0.999 * S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0]) / (Math.Pow((0.001 * S), 2));
            return gamma;
        }
        //Vega
        public static double Vega(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double vega = (EuropeanOption.OptionPrice(S, K, R, 1.1 * Sigma, T, Sims, Steps, IsCall, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, R, 0.9 * Sigma, T, Sims, Steps, IsCall, Epsilon)[0]) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public static double Theta(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double theta = (EuropeanOption.OptionPrice(S, K, R, Sigma, 1.1 * T, Sims, Steps, IsCall, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0]) / (0.1 * T);
            return theta;
        }
        //Rho
        public static double Rho(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, double[,] Epsilon)
        {
            double rho = (EuropeanOption.OptionPrice(S, K, 1.1 * R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, 0.9 * R, Sigma, T, Sims, Steps, IsCall, Epsilon)[0]) / (0.2 * R);
            return rho;
        }
    }
}
