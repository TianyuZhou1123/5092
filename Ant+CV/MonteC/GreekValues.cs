using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteC
{
    class GreekValues
    {
        public static double Delta(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, double[,] Epsilon)
        {
            double delta = (EuropeanOption.OptionPrice(1.01 * S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] - EuropeanOption.OptionPrice(0.99 * S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0]) / (0.02 * S);
            return delta;
        }
        public static double Gamma(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, double[,] Epsilon)
        {
            double gamma = (EuropeanOption.OptionPrice(1.01 * S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] - 2 * EuropeanOption.OptionPrice(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] + EuropeanOption.OptionPrice(0.99 * S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0]) / (Math.Pow((0.01 * S), 2));
            return gamma;
        }
        public static double Theta(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, double[,] Epsilon)
        {
            double theta = -(EuropeanOption.OptionPrice(S, K, Mu, Sigma, 1.001 * T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, Mu, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0]) / (0.001 * T);
            return theta;
        }
        public static double Vega(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, double[,] Epsilon)
        {
            double vega = (EuropeanOption.OptionPrice(S, K, Mu, 1.001 * Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, Mu, 0.999 * Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0]) / (0.002 * Sigma);
            return vega;
        }
        public static double Rho(double S, double K, double R, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, double[,] Epsilon)
        {
            double rho = (EuropeanOption.OptionPrice(S, K, 1.001 * R, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0] - EuropeanOption.OptionPrice(S, K, 0.999 * R, Sigma, T, Sims, Steps, IsCall, Ant, CV, Epsilon)[0]) / (0.002 * R);
            return rho;
        }
    }
}
