using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEquationsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите начальную координату х0: ");
                double x0 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите начальную координату y0: ");
                double y0 = Convert.ToDouble(Console.ReadLine());

                PrintResults(RungeKuttaMethod4(x0, y0, 1, 10));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static List<List<double>> RungeKuttaMethod4(double xi, double yi, double h0, int m)
        {
            List<List<double>> results = new List<List<double>>();
            List<double> massX = new List<double>();
            List<double> massY = new List<double>();
            double h = h0 / m;
            double x = xi;
            double y = yi;

            massX.Add(x);
            massY.Add(y);

            for (int j = 1; j <= m; j++)
            {
                double k1 = F(x, y);
                double k2 = F(x + h / 2, y + h / 2 * k1);
                double k3 = F(x + h / 2, y + h / 2 * k2);
                double k4 = F(x + h, y + h*k3);

                y = y + h/6 * (k1 + 2 * k2 + 2 * k3 + k4);
                x = xi + j * h;
                massX.Add(x);
                massY.Add(y);
            }

            results.Add(massX);
            results.Add(massY);

            return results;
        }

        static double F(double x, double y)
        {
            //return 3 * x * x * y + x * x * Math.Pow(Math.E, Math.Pow(x, 3));
            return y * Math.Cos(x);
        }

        static void PrintResults(List<List<double>> results)
        {
            Console.Write("x\t");
            for (int i = 0; i < results[0].Count; i++)
                Console.Write(Math.Round(results[0][i], 4) + "\t");

            Console.Write("\ny\t");
            for (int i = 0; i < results[1].Count; i++)
                Console.Write(Math.Round(results[1][i], 4) + "\t");

            Console.Write("\n");
        }
    }
}
