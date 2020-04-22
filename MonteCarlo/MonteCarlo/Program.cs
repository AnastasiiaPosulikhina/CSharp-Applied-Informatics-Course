using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            MonteCarloMethod();
        }

        static void MonteCarloMethod()
        {
            int N = 1000000;
            int n = 0;
            double x, y;
            Random r = new Random();

            for(int i = 0; i < N; i++)
            {
                x = r.NextDouble();
                y = r.NextDouble();

                if (x * x + y * y < 1)
                    n++;
            }

            double pi = (4.0 * n) / N;

            Console.WriteLine("Pi = {0:0.###}", pi);
        }
    }
}
