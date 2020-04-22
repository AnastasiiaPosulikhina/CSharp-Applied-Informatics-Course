using System;
using System.Collections.Generic;

namespace Graphs
{
    class GraphAssignment
    {
        public static void MakeMatrix(bool isAdjacencyMatrix)
        {
            int[,] graph = { };
            int n = int.MaxValue;
            int m = int.MaxValue;
            try
            {
                if (isAdjacencyMatrix == true)
                {
                    Console.WriteLine("*** Алгоритм способа задания графа с помощью матрицы смежности ***\n");
                }
                else
                {
                    Console.WriteLine("\n*** Алгоритм способа задания неориентированного графа с помощью матрицы инцидентности ***\n");
                    Console.Write("Введите количество рёбер графа: ");

                    m = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Введите количество вершин графа: ");
                n = Convert.ToInt32(Console.ReadLine());

                if (m == int.MaxValue) //если пользователь не вводил количество рёбер, то строится матрица смежности
                    m = n;

                graph = new int[n, m];
                int[] edgesCount = new int[m]; //подсчёт кол-ва рёбр при составлении матрици инцидентности

                for (int i = 0; i < n; i++)
                {
                    if (n == m)
                        Console.Write($"Введите через пробел номера вершин, с которыми у вершины {i + 1} есть связи, или \"0\" - если их нет: ");
                    else
                        Console.Write($"Введите через пробел номера рёбер, с которыми у вершины {i + 1} есть связи, или \"0\" - если их нет: ");

                    string s = Console.ReadLine();
                    string[] elemNumbersString = s.Split(new char[] { ' ' });
                    List<int> elemNumbers = new List<int>();
                    int count = 0;
                    int k;

                    for (int j = 0; j < elemNumbersString.Length; j++)
                    {
                        if (int.TryParse(elemNumbersString[j], out k))
                        {
                            if (k > 0 && k <= m && edgesCount[k-1] < 2 && n != m)
                            {
                                elemNumbers.Add(k);
                                edgesCount[k-1]++;
                            }
                            else if (k > 0 && k <= m && n == m)
                                elemNumbers.Add(k); 
                            else if (k == 0)
                                continue;
                            else
                                Console.WriteLine($"Введены некорректные данные! Число {k} не может являться ребром графа!");
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }

                    elemNumbers.Sort();

                    for (int j = 0; j < m; j++)
                    {
                        if (count < elemNumbers.Count && (elemNumbers[count] == (j + 1)))
                        {
                            graph[i, j] = 1;
                            count++;
                        }
                    }
                }

                PrintMatrix(graph, n, m);
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные!");
            }
        }

        public static void MakeIncidenceMatrixToDG()
        {
            Console.WriteLine("\n*** Алгоритм способа задания ориентированного графа с помощью матрицы инцидентности ***\n");
            int[,] graph = { };
            int n = int.MaxValue;
            int m = int.MaxValue;
            try
            {
                Console.Write("Введите количество вершин графа: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество рёбер графа: ");
                m = Convert.ToInt32(Console.ReadLine());
                graph = new int[n, m];
                int[] edgesCount = new int[m]; //подсчёт кол-ва рёбр при составлении матрици инцидентности

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Введите через пробел номера рёбер, которые выходят из вершины {i + 1}, или \"0\" - если их нет: ");

                    string s = Console.ReadLine();
                    string[] elemNumbersString = s.Split(new char[] { ' ' });
                    List<int> elemNumbers = new List<int>();
                    int count = 0;
                    int k;

                    //ребра, которые выходят из вершины
                    for (int j = 0; j < elemNumbersString.Length; j++)
                    {
                        if (int.TryParse(elemNumbersString[j], out k))
                        {
                            if (k > 0 && k <= m && edgesCount[k - 1] < 2)
                            {
                                elemNumbers.Add(k);
                                edgesCount[k - 1]++;
                            }
                            else if (k == 0)
                                continue;
                            else
                                Console.WriteLine($"Введены некорректные данные! Число {k} не может являться ребром графа!");
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }

                    elemNumbers.Sort();

                    for (int j = 0; j < m; j++)
                    {
                        if (count < elemNumbers.Count && (elemNumbers[count] == (j + 1)))
                        {
                            graph[i, j] = 1;
                            count++;
                        }
                    }

                    Console.Write($"Введите через пробел номера рёбер, которые входят в вершину {i + 1}, или \"0\" - если их нет: ");
                    s = Console.ReadLine();
                    elemNumbersString = s.Split(new char[] { ' ' });
                    elemNumbers = new List<int>();
                    count = 0;

                    //рёбра, которые входят в вершину
                    for (int j = 0; j < elemNumbersString.Length; j++)
                    {
                        if (int.TryParse(elemNumbersString[j], out k))
                        {
                            if (k > 0 && k <= m && edgesCount[k - 1] < 2)
                            {
                                elemNumbers.Add(k);
                                edgesCount[k - 1]++;
                            }
                            else if (k == 0)
                                continue;
                            else
                                Console.WriteLine($"Введены некорректные данные! Число {k} не может являться ребром графа!");
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }

                    elemNumbers.Sort();

                    for (int j = 0; j < m; j++)
                    {
                        if (count < elemNumbers.Count && (elemNumbers[count] == (j + 1)))
                        {
                            graph[i, j] = -1;
                            count++;
                        }
                    }
                }

                PrintMatrix(graph, n, m);
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректные данные!");
            }
        }

        public static void PrintMatrix(int[,] graph, int n, int m)
        {
            if (n > 0)
            {
                if (n == m)
                    Console.WriteLine("Матрица смежности графа:");
                else
                    Console.WriteLine("Матрица инцидентности графа:");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if ((graph[i, j] == -1) && (i != 0))
                            Console.Write(graph[i, j] + " ");
                        else
                            Console.Write(graph[i, j] + "  ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
