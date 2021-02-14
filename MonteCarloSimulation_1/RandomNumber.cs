using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteC
{
    class RandomNumber
    {
        public static double Polar_rejection()
        {
            Random rnd = new Random();
            double u1, u2, v1 = 0, v2 = 0, s = 0, z1 = 0;
            do
            {
                u1 = rnd.NextDouble();
                u2 = rnd.NextDouble();
                v1 = 2 * u1 - 1;//The polar method works by choosing random points (x, y) in the square −1 < x < 1, −1 < y < 1
                v2 = 2 * u2 - 1;
                s = v1 * v1 + v2 * v2;

            }
            while (s > 1 || s == 0);
            z1 = Math.Sqrt(-2 * Math.Log(s) / s) * v1;
            return z1;
        }
        //RN store the random numbers
        public double[,] Epsilon(int Sims, int Steps)
        {
            double[,] randomnumber = new double[Sims, Steps];
            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    randomnumber[i, j] = Polar_rejection();
                }
            }
            return randomnumber;
        }
    }
}
