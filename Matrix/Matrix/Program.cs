using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = -1; 
            Console.Write("Введите размерность матрицы: ");
            double[,] matrix1 = { };

            try
            {
                matrix1 = MatrixMaker(out n);
            }

            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.GetType().Name);
            }

            if (n > 0)
            {
                Console.WriteLine("\n*** Сложение матриц ***\n");
                SumMatrix(matrix1, n);

                Console.WriteLine("\n*** Перемножение матриц ***\n");
                MultiplyMatrix(matrix1, n);

                Console.WriteLine("\n*** Нахождение обратной матрицы ***\n");
                GetInverseMatrix(matrix1, n);
            }

        }

        public static double[,] SumMatrix(double[,] matrix1, int n)
        {
            int m;
            Console.Write("Введите размерность второй матрицы: ");
            double[,] matrix2 = MatrixMaker(out m);

            double[,] finalMatrix = { };
            if (n == m)
            {
                finalMatrix = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        finalMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                MatrixPrinter(finalMatrix);
            }
            else
                Console.WriteLine("К сожалению, нельзя складывать матрицы разного ранга!");

            return finalMatrix;
        }

        public static double[,] MultiplyMatrix(double[,] matrix1, int n)
        {
            int m;
            Console.Write("Введите размерность второй матрицы: ");
            double[,] matrix2 = MatrixMaker(out m);

            double[,] finalMatrix = { };
            if (n == m)
            {
                finalMatrix = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        finalMatrix[i, j] = 0;
                        int r = 0;
                        while(r != n)
                        {
                            finalMatrix[i, j] += matrix1[i, r] * matrix2[r, j];
                            r++;
                        }
                    }
                }

                MatrixPrinter(finalMatrix);
            }
            else
                Console.WriteLine("К сожалению, нельзя перемножить данные матрицы!");

            return finalMatrix;
        }

        public static double[,] GetInverseMatrix(double[,] matrix, int n)
        {
            double det = GetDeterminant(matrix);
            double[,] finalMatrix = new double[n, n];

            try
            {
                if(det == 0)
                    throw new DivideByZeroException();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        finalMatrix[i, j] = Math.Pow(-1, i + j) * GetDeterminant(GetMinor(matrix, i, j));
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        double t = finalMatrix[i, j] / det;
                        Console.WriteLine(t);
                        finalMatrix[i, j] = finalMatrix[j, i] / det;
                        finalMatrix[j, i] = t;
                    }
                }
            }

            catch(DivideByZeroException e)
            {
                Console.WriteLine("Определитель матрицы равен нулю (матрица является вырожденной), поэтому нельзя получить обратную матрицу.");
            }

            finally
            {
                if (det != 0)
                    MatrixPrinter(finalMatrix);
            }

            return finalMatrix;
        }

        public static double GetDeterminant(double[,] matrix) 
        {
            int n = matrix.GetLength(0);
            double det = 0;

            if (n == 1)
                det = matrix[0, 0];
            else if (n == 2)
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1,0 + j) * matrix[0, j] * GetDeterminant(GetMinor(matrix, 0, j));
                }
            }

            return det;
        }

        public static double[,] GetMinor(double[,] matrix, int row, int col)
        {
            double[,] minor = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != col))
                    {
                        if (i > row && j < col)
                            minor[i - 1, j] = matrix[i, j];
                        if (i < row && j > col)
                            minor[i, j - 1] = matrix[i, j];
                        if (i > row && j > col)
                            minor[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < col)
                            minor[i, j] = matrix[i, j];
                    }
                }

            return minor;
        }

        public static void MatrixPrinter(double[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix.GetUpperBound(1) + 1;

            Console.WriteLine("Полученная матрица имеет вид: ");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static double[,] MatrixMaker(out int k)
        {
            
            k = Convert.ToInt32(Console.ReadLine());
            double[,] matrix2 = { };

            try
            {
                if (k > 0)
                {
                    matrix2 = new double[k, k];
                    Console.WriteLine("Введите последовательно элементы матрицы, начиная с элементов первой строки:");
                    for (int i = 0; i < k; i++)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            matrix2[i, j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }
                }
                else
                    Console.WriteLine("Размерность матрицы не может быть неположительным числом.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e.GetType().Name);
            }

            return matrix2;
        }
    }
}
