using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonteC
{
    class Allsims
    {
        bool mt;
        public bool MT { get { return mt; } set { mt = value; } }
        public double[,] allsims_calculate(double S, double K, double Mu, double Sigma, double T, int Sims, int Steps, bool IsCall, bool Ant, bool CV, bool MT, double[,] Epsilon)
        {
            //  RandomNumber random = new RandomNumber();
            //if (MT == true)
            //  Epsilon = random.Increment();
            //else
            //  Epsilon = random.rn();
            int cores_num;
            if (MT)
                //cores_num =4;
                cores_num = System.Environment.ProcessorCount;
            else
                cores_num = 1;
            int each_task;
            // sepearate tasks for each core
            if (Sims % cores_num == 0)
                each_task = 2 * Sims / cores_num;
            else
                each_task = 2 * Sims / cores_num + 1;

            //allsims store the price of each step
            double[,] allsims;
            if (Ant)
                allsims = new double[2 * Sims, Steps + 1];
            else
                allsims = new double[Sims, Steps + 1];
            //let the first column be S
            for (int i = 0; i < allsims.GetLength(0); i++)
                allsims[i, 0] = S;

            // List<Thread> thread = new List<Thread>();
            Action<Object> Mult = (mt) =>
            {
                int tasks = Convert.ToInt32(mt) + each_task;
                // in last core, if the number of tasks is small, suppose it do the left tasks
                if (tasks > Sims)
                    tasks = Sims;
                //calculate the option price step by step
                for (int i = Convert.ToInt32(mt); i < tasks; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) + Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                        if (Ant)
                            allsims[i + Sims, j + 1] = allsims[i + Sims, j] * Math.Exp((Mu - Sigma * Sigma / 2) * (T / Steps) - Sigma * Math.Sqrt(T / Steps) * Epsilon[i, j]);
                    }
                }
            };
            List<Thread> thread = new List<Thread>();
            int iter = 0;
            for (int i = 0; i < cores_num; i++)
            {
                thread.Add(new Thread(new ParameterizedThreadStart(Mult)));
                thread[i].Start(iter);
                iter = iter + each_task;
            }
            foreach (Thread i in thread)
                i.Join();
            // foreach (Thread i in thread)
            //   i.Abort();
            return allsims;
        }
    }
}

