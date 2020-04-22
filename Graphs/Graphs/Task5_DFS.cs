using System;

namespace Graphs
{
    class Task5_DFS
    {
        const int n = 5;
        static bool[] visited = new bool[n];

        //матрица смежности графа 
        static int[,] graph = new int[n, n]
        {
            {0, 1, 0, 0, 1},
            {1, 0, 1, 1, 0},
            {0, 1, 0, 0, 1},
            {0, 1, 0, 0, 1},
            {1, 0, 1, 1, 0}
        };

        public static void DFSrealization()
        {
            Console.WriteLine("\n*** Реализация алгоритма обхода графа - поиск в глубину ***\n");
            Console.WriteLine("Матрица смежности графа:");

            for (int i = 0; i < n; i++)
            {
                visited[i] = false;

                for (int j = 0; j < n; j++)
                    Console.Write(graph[i, j] + " ");

                Console.WriteLine();
            }

            try
            {
                Console.Write("Стартовая вершина: ");
                int start = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Порядок обхода: ");
                DFS(start - 1);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Введены некорректные данные!");
            }
        }

        static void DFS(int st)
        {
            Console.Write(st + 1 + " ");

            visited[st] = true;

            for (int r = 0; r < n; r++)
                if ((graph[st, r] != 0) && (visited[r] == false))
                    DFS(r);
        }
    }
}
