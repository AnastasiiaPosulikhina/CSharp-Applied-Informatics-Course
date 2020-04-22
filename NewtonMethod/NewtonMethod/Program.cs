using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    class Program
    {
        public static List<List<double>> matrix = new List<List<double>>();
        public static List<double> newCoefficients = new List<double>();
        public static List<double> coefsAfterDerivation = new List<double>();

        static void Main(string[] args)
        {
            matrix = GetSystemOfEquations();            //получаем матрицу коэффициентов системы двух показательных уравнений
            PrintSystemOfEquations(matrix);             //выводим систему пользователю на экран
            newCoefficients = GetOneEquation(matrix);   //приравниваем два уравнения системы и получаем новые коэффициенты
            coefsAfterDerivation = TakeTheDerivative(newCoefficients);  //получаем коээфициенты после взятия производной

            try
            {
                Console.Write("\nВведите левую границу интервала: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите правую границу интервала: ");
                double b = Convert.ToDouble(Console.ReadLine());
                double e = 0.00001;
                double x = (a + b) / 2;
                x = GetXWithNewtonMethod(x, e);

                Console.WriteLine("Ответ:\nx = " + x);
                Console.WriteLine("y = " + GetY(x));
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        static List<List<double>> GetSystemOfEquations() 
        {
            List<List<double>> coefficientMatrix = new List<List<double>>();
            List<double> coefficients1 = new List<double>();
            List<double> coefficients2 = new List<double>();

            try
            {
                Console.Write("Введите степень первого уравнения системы: ");
                int degree = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите коэффициенты первого уравнения системы: ");
                for (int i = degree; i >= 0; i--)
                {
                    Console.Write($"Коэффициент при x^{i} = ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    coefficients1.Add(x);
                }

                Console.Write("\nВведите степень второго уравнения системы: ");
                degree = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите коэффициенты второго уравнения системы: ");
                for (int i = degree; i >= 0; i--)
                {
                    Console.Write($"Коэффициент при x^{i} = ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    coefficients2.Add(x);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }

            coefficientMatrix.Add(coefficients1);
            coefficientMatrix.Add(coefficients2);

            return coefficientMatrix;
        }

        static void PrintSystemOfEquations(List<List<double>> matrix)
        {
            Console.WriteLine("\nПолученная система из двух уравнений имеет вид:");

            for (int j = 0; j < 2; j++)
            {
                Console.Write("y = ");

                for (int i = 0; i < matrix[j].Count; i++)
                {
                    if (matrix[j].Count - 1 - i == 1)
                        Console.Write($"{matrix[j][i]}x + ");
                    else if (matrix[j].Count - 1 - i == 0)
                        Console.Write($"{matrix[j][i]}\n");
                    else
                        Console.Write($"{matrix[j][i]}x^{matrix[j].Count - 1 - i} + ");
                }
            }
        }

        static List<double> GetOneEquation(List<List<double>> coefficientMatrix)
        {
            int minLength, indexOfMinLengthMass, anotherIndex;
            List<double> newCoefficients = new List<double>();

            if (coefficientMatrix[0].Count < coefficientMatrix[1].Count)
            {
                minLength = coefficientMatrix[0].Count;
                indexOfMinLengthMass = 0;
                anotherIndex = 1;
            }
            else
            {
                minLength = coefficientMatrix[1].Count;
                indexOfMinLengthMass = 1;
                anotherIndex = 0;
            }

            int n = coefficientMatrix[anotherIndex].Count - 1;

            for (int i = minLength - 1; i >= 0; i--)
            {
                newCoefficients.Add(coefficientMatrix[anotherIndex][n] - coefficientMatrix[indexOfMinLengthMass][i]);
                n--;
            }

            for (int i = n; i >= 0; i--)
                newCoefficients.Add(coefficientMatrix[anotherIndex][i]);

            newCoefficients.Reverse();

            return newCoefficients;
        }

        static List<double> TakeTheDerivative(List<double> newCoefficients)
        {
            List<double> coefsAfterDerivation = new List<double>();
            int j = 0;

            for(int i = newCoefficients.Count - 1; i > 0; i--)
            {
                coefsAfterDerivation.Add(newCoefficients[j] * i);
                j++;
            }

            return coefsAfterDerivation;
        }

        static double GetXWithNewtonMethod(double x, double e)
        {
            double dx, xk, d;
            int k = 0;

            do
            {
                xk = x - F(x) / dF(x);
                d = Math.Abs(xk - x);

                if (d < e)
                    return xk;

                x = xk;
                k++;

            }
            while (true);
        }

        static double F(double x)
        {
            double F = 0;
            int degree = newCoefficients.Count - 1;

            for (int i = 0; i < newCoefficients.Count; i++)
            {
                double d = newCoefficients[i];

                for (int j = 0; j < degree; j++)
                {
                    d *= x;
                }

                degree--;
                F += d;
            }

            return F;
        }

        static double dF(double x)
        {
            double dF = 0;
            int degree = coefsAfterDerivation.Count - 1;

            for (int i = 0; i < coefsAfterDerivation.Count; i++)
            {
                double d = coefsAfterDerivation[i];

                for (int j = 0; j < degree; j++)
                {
                    d *= x;
                }

                degree--;
                dF += d;
            }

            return dF;
        }

        static double GetY(double x)
        {
            double y = 0;
            int degree = matrix[0].Count - 1;

            for (int i = 0; i < matrix[0].Count; i++)
            {
                double d = matrix[0][i];

                for (int j = 0; j < degree; j++)
                {
                    d *= x;
                }

                degree--;
                y += d;
            }

            return y;
        }
    }
}
