using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonteC
{
    class RandomNumber
    {

        static int GetRandomSeed()//Let random numbers don't match with each other
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        static double BoxMuller()//
        {
            //randn1 and randn2 are 2 uniform random values between 0 and 1
            double randn1, randn2;
            Random rnd1 = new Random(GetRandomSeed());
            Random rnd2 = new Random(GetRandomSeed());
            randn1 = rnd1.NextDouble();
            randn2 = rnd2.NextDouble();
            double z1 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Cos(2 * Math.PI * randn2);
            return z1;
        }

        public double[,] rn(int Sims, int Steps)
        {
            double[,] randomnumber = new double[Sims, Steps];
            double randn1, randn2;
            Random rnd1 = new Random(GetRandomSeed());
            Random rnd2 = new Random(GetRandomSeed());

            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    randn1 = rnd1.NextDouble();
                    randn2 = rnd2.NextDouble();
                    double z1 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Cos(2 * Math.PI * randn2);
                    randomnumber[i, j] = z1;
                }
            }
            return randomnumber;
        }

        // public double[,] Increment(int Sims,int Steps)
        //public delegate double[,] rnDelegate(int Sims, int Steps);
        public double[,] Increment(int Sims, int Steps)
        {
            double[,] randomnumber = new double[Sims, Steps];
            int cores_num = System.Environment.ProcessorCount;//cores_num = 4;
            int each_task = 2 * Sims / cores_num;
            //multithreading
            Action<object> MT = (mt) =>
            {
                int tasks = Convert.ToInt32(mt) + each_task;
                double randn1, randn2;
                Random rnd1 = new Random(GetRandomSeed());
                Random rnd2 = new Random(GetRandomSeed());

                for (int i = Convert.ToInt32(mt); i < tasks; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        randn1 = rnd1.NextDouble();
                        randn2 = rnd2.NextDouble();
                        double z1 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Cos(2 * Math.PI * randn2);
                        randomnumber[i, j] = z1;
                    }
                }
            };
            int iter = 0;
            List<Thread> thread = new List<Thread>();
            for (int i = 0; i < cores_num / 2; i++)
            {
                Thread new_thread = new Thread(new ParameterizedThreadStart(MT));
                thread.Add(new_thread);
                new_thread.Start(iter);
                iter = iter + each_task;
            }
            foreach (Thread i in thread)
                i.Join();
            foreach (Thread i in thread)
                i.Abort();
            return randomnumber;

        }

    }
}

