using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;

namespace Runge_Kutta_MethodV2
{
    internal class Program
    {
         const int n = 2; //number of system equations
         
         static void Main(string[] args)
         {
            try
            {
               Console.Write("Enter the right border: ");
               double a = Convert.ToDouble(Console.ReadLine());

               Console.Write("Enter the initial conditions:");
               Console.Write("x0 = ");

               double x0 = Convert.ToDouble(Console.ReadLine());
               double[] initialConditions = new double[n];

               for (int i = 0; i < n; i++)
               {
                  Console.Write($"y{i + 1}({x0}) = ");
                  double y = Convert.ToDouble(Console.ReadLine());
                  initialConditions[i] = y;
               }

               double[,] res = RungeKuttaMethod4(x0, initialConditions[0], initialConditions[1], a - x0, 10);
               PrintResults(res);
            }
            catch (Exception e)
            {
               Console.WriteLine("Error: " + e.Message);
            }
         }

         static double[,] RungeKuttaMethod4(double xi, double y1i, double y2i, double h0, int m)
         {
            double[,] res = new double[m + 1, n + 1];
            
            double h = h0 / m;
            double x = xi;
            double y1 = y1i;
            double y2 = y2i;

            res[0, 0] = x;
            res[0, 1] = y1;
            res[0, 2] = y2;

            for (int j = 1; j <= m; j++)
            {
                double k1 = F1(x, y1, y2);
                double l1 = F2(x, y1, y2);
                
                double k2 = F1(x + h / 2, y1 + h / 2 * k1, y2 + h / 2 * l1);
                double l2 = F2(x + h / 2, y1 + h / 2 * k1, y2 + h / 2 * l1);
                
                double k3 = F1(x + h / 2, y1 + h / 2 * k2, y2 + h / 2 * l2);
                double l3 = F2(x + h / 2, y1 + h / 2 * k2, y2 + h / 2 * l2);
                
                double k4 = F1(x + h, y1 + h*k3, y2 + h*l3);
                double l4 = F2(x + h, y1 + h*k3, y2 + h*l3);
                y1 = y1 + h/6 * (k1 + 2 * k2 + 2 * k3 + k4);
                y2 = y2 + h/6 * (l1 + 2 * l2 + 2 * l3 + l4);
                
                x = xi + j * h;

                res[j, 0] = x;
                res[j, 1] = y1;
                res[j, 2] = y2;
            }

            return res;
         }
         
         static double F1(double x, double y1, double y2)
         {
            return y2;
         }
         
         static double F2(double x, double y1, double y2)
         {
            return 2 * x * y2/(x * x + 1);
         }

         static void PrintResults(double[,] res)
         {
            Console.Write("x\t\ty1\t\t\ty2\t\t\ty1 (exact)\t\ty2 (exact)\n");
            
            double[] exactSolutionY1 = {1, 1.300998, 1.6080012, 1.927000, 2.264001, 2.624998,  3.015998, 3.442998, 3.911997, 4.428987, 4.999987};
            double[] exactSolutionY2 = {3, 3.030011, 3.120002, 3.270001, 3.480002, 3.750001, 4.080001, 4.470001, 4.920001, 5.430001, 6.000001};

            for (int i = 0; i < res.GetLength(0); i++)
            {
               for (int j = 0; j < res.GetLength(1); j++)
               {
                  if (j == 0)
                  {
                     Console.Write(res[i, j] + "\t\t");
                  }
                  else
                  {
                     Console.Write(String.Format("{0:0.000000}", res[i, j]) + "\t\t");
                  }
               }
               
               Console.Write(String.Format("{0:0.000000}", exactSolutionY1[i]) + "\t\t");
               Console.Write(String.Format("{0:0.000000}", exactSolutionY2[i]) + "\t\t");
               
               Console.WriteLine("");
            }
         }
    }
}