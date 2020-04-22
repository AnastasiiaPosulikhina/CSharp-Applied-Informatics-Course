using System;

namespace GaussMethod
{
    class Program
    {
        static bool isMatrixMade = false;

        static void Main(string[] args)
        {
            int n = 0, m = 0;
            try
            {
                Console.Write("Введите количество переменных системы: ");
                n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите количество уравнений системы: ");
                m = Convert.ToInt32(Console.ReadLine());
            
                double[,] matrix = MatrixMaker(n, m);

                if(isMatrixMade)
                    MatrixPrinter(matrix);

                if (isSolutionSingle(matrix) && isMatrixMade)
                {
                    double[] results = GaussMethod(matrix);

                    Console.WriteLine("Ответ: ");
                    foreach (double res in results)
                        Console.Write(res + "; ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        static double[] GaussMethod(double[,] matrix)
        {

            double[] results = new double[matrix.GetLength(1) - 1];
            int nb = matrix.GetLength(1) - 1;

            for(int n = results.Length - 1; n >= 0; n--)
            {
                double sum = 0;

                for (int i = n + 1; i < nb; i++)
                    sum += results[i] * matrix[n, i];

                results[n] = (matrix[n, nb] - sum) / matrix[n, n];
            }

            return results;
        }

        static bool isSolutionSingle(double[,] matrix)
        {
            int CMR = 0;
            int EMR = 0;
            int coefficientMatrixRank = matrix.GetLength(0);
            int extendedMatrixRank = matrix.GetLength(0);

            double[,] triangleMatrix = TriangleMatrixMaker(matrix);

            for(int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if(matrix[i,j] == 0 && j == matrix.GetLength(1) - 1)
                    {
                        EMR++;
                    }
                    else if(matrix[i, j] == 0)
                    {
                        CMR++;
                        EMR++;
                    }
                }

                if (CMR == matrix.GetLength(1) - 1)
                    coefficientMatrixRank--;

                if (EMR == matrix.GetLength(1))
                    extendedMatrixRank--;

                CMR = 0;
                EMR = 0;
            }
        
            if (coefficientMatrixRank != extendedMatrixRank && isMatrixMade)
            {
                Console.WriteLine("Ранги матрицы различны, а значит, система несовместна!");
                return false;
            }
            else if (coefficientMatrixRank == extendedMatrixRank && coefficientMatrixRank < matrix.GetLength(1) - 1 && isMatrixMade)
            {
                Console.WriteLine("Система совместна, но имеет бесконечное множество решений!");
                return false;
            }
            else
                return true;
        }

        static double[,] TriangleMatrixMaker(double[,] matrix)
        {
            double[,] triangleMatrix = { };

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                LeadingRowChoice(matrix, i - 1);

                if (Math.Abs(matrix[i - 1, i - 1]) >= 0)
                {
                    triangleMatrix = SubstractRow(matrix, i - 1);
                }

            }

            return triangleMatrix;
        }

        static double[,] SubstractRow(double[,] matrix, int subtractedRow)
        {
            double m = matrix[subtractedRow, subtractedRow];

            for (int i = subtractedRow + 1; i < matrix.GetLength(0); i++)
            {
                double t = matrix[i, subtractedRow] / m;

                for (int j = subtractedRow; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] - matrix[subtractedRow, j] * t;
                }
            }

            return matrix;
        }

        static void LeadingRowChoice(double[,] matrix, int rowNumber)
        {
            int maxIndex = rowNumber;

            for (int i = rowNumber + 1; i < matrix.GetLength(0); i++)
                if (Math.Abs(matrix[maxIndex, rowNumber]) < Math.Abs(matrix[i, rowNumber]))
                    maxIndex = i;

            if(maxIndex != rowNumber)
            {
                for(int i = rowNumber; i < matrix.GetLength(1); i++)
                {
                    double t = matrix[rowNumber, i];
                    matrix[rowNumber, i] = matrix[maxIndex, i];
                    matrix[maxIndex, i] = t;
                }
            }
        }

        static double[,] MatrixMaker(int n, int m)
        {
            double[,] matrix = { };

            try
            {
                if (n > 0 && m > 0)
                {
                    matrix = new double[m, n + 1];
                    Console.WriteLine("Введите матрицу коэффициентов, т.е. последовательно все элементы матрицы, начиная с первой строки:");

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write($"a[{i}][{j}] = ");
                            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }

                    Console.WriteLine("Введите матрицу свободных членов:");
                    for (int i = 0; i < m; i++)
                    {
                        Console.Write($"a[{i}][{n}] = ");
                        matrix[i, n] = Convert.ToDouble(Console.ReadLine());
                    }

                    isMatrixMade = true;
                }
                else
                    Console.WriteLine("Размерность матрицы не может быть неположительным числом.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }

            return matrix;
        }

        static void MatrixPrinter(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix.GetUpperBound(1);

            Console.WriteLine("Расширенная матрица системы имеет вид: ");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }

                Console.Write("| \t");
                Console.Write($"{matrix[i, cols]} \t");

                Console.WriteLine();
            }
        }
    }
}
