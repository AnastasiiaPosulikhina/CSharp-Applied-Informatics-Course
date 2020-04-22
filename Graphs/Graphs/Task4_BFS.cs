using System;

namespace Graphs
{
    class Task4_BFS
    {
        const int n = 4;

        //матрица смежности графа 
        static int[,] graph = new int[n, n]
        {
            {0, 1, 1, 0},
            {0, 0, 1, 1},
            {1, 0, 0, 1},
            {0, 1, 0, 0}
        };

        public static void BFSrealization()
        {
            bool[] visited = new bool[n];
            Console.WriteLine("*** Реализация алгоритма обхода графа - поиск в ширину ***\n");
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
                BFS(visited, start - 1);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Введены некорректные данные!");
            }
        }

        static void BFS(bool[] passed, int unit)
        {
            int[] queue = new int[n]; //массив, хранящий задействованные узлы
            int count = 0, head = 0;

            for (int i = 0; i < n; i++)
                queue[i] = 0;

            queue[count++] = unit; //стартовая вершина помещается в очередь
            passed[unit] = true; //стартовая вершина помечается как посещенная, смежные с ней - в конец очереди

            while(head < count)
            {
                unit = queue[head++]; 
                Console.Write(unit + 1 + " ");

                for(int i = 0; i < n; i++)
                {
                    if(graph[unit,i] != 0 && !passed[i])
                    {
                        queue[count++] = i;
                        passed[i] = true;
                    }
                }
            }
        }
    }
}
