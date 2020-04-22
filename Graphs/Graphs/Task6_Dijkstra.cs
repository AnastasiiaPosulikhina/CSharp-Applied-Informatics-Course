using System;

namespace Graphs
{
    class Task6_Dijkstra
    {
        const int V = 6;

        //матрица смежности графа 
        static int[,] graph = new int[V, V]
        {
            {0, 1, 4, 0, 2, 0},
            {0, 0, 0, 9, 0, 0},
            {4, 0, 0, 7, 0, 0},
            {0, 9, 7, 0, 0, 2},
            {0, 0, 0, 0, 0, 8},
            {0, 0, 0, 0, 0, 0}
        };

        public static void DijkstraRealization()
        {
            Console.WriteLine("\n*** Реализация алгоритма Дейкстры ***\n");
            Console.WriteLine("Матрица смежности графа:");

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                    Console.Write(graph[i, j] + " ");

                Console.WriteLine();
            }

            try
            {
                Console.Write("Стартовая вершина: ");
                int start = Convert.ToInt32(Console.ReadLine());
                Dijkstra(graph, start - 1);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Введены некорректные данные!");
            }
        }

        static void Dijkstra(int[,] graph, int st)
        {
            int[] distance = new int[V]; //массив кратчайших путей
            bool[] visited = new bool[V]; 
            int index = -1, u;

            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }

            distance[st] = 0;

            for(int count = 0; count < V-1; count++)
            {
                int min = int.MaxValue;

                for(int i = 0; i < V; i++)
                    if(!visited[i] && (distance[i] <= min))
                    {
                        min = distance[i];
                        index = i;
                    }

                u = index;
                visited[u] = true;

                for (int i = 0; i < V; i++)
                    if (!visited[i] && graph[u, i] != 0 && distance[u] != int.MaxValue && (distance[u] + graph[u, i] < distance[i]))
                        distance[i] = distance[u] + graph[u, i];
            }

            Console.WriteLine("Стоимость пути из начальной вершины до остальных:");
            for (int i = 0; i < V; i++)
            {
                if (distance[i] != int.MaxValue)
                    Console.WriteLine(st + 1 + " > " + (i + 1) + " = " + distance[i]);
                else
                    Console.WriteLine(st + 1 + " > " + (i + 1) + " = маршрут недоступен!");
            }  
        }
    }
}
