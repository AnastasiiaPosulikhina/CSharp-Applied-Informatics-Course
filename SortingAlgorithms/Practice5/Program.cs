using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 3, 9, 0, 12, 4, 6, 8, 1, 1, 7, 456, 3, 1111, 23 };

            //Сортировка вставками
            Console.WriteLine("*** Сортировка вставками ***");
            List<int> sortedList1 = InsertionSort(list);

            foreach (int n in sortedList1)
                Console.Write(n + " ");

            Console.WriteLine();

            //Сортировка выбором
            Console.WriteLine("\n*** Сортировка выбором ***");
            List<int> sortedList2 = SelectionSort(list);

            foreach (int n in sortedList2)
                Console.Write(n + " ");

            Console.WriteLine();

            //Пузырьковая сортировка
            Console.WriteLine("\n*** Пузырьковая сортировка ***");
            List<int> sortedList3 = BubbleSort(list);

            foreach (int n in sortedList3)
                Console.Write(n + " ");
        }

        //Task1 - функция обмена значениями без использования третьей переменной
        static void Swap(int a, int b)
        {           
            b = b - a;
            a = a + b;
            b = a - b;
        }

        //Сортировка вставками
        static List<int> InsertionSort(List<int> list)
        {
            int key, j;

            for(int i = 1; i < list.Count; i++)
            {
                key = list[i]; //выбор элемента из списка ввода
                j = i - 1;     //индекс предыдущего элемента

                while(-1 < j && key < list[j]) //пока элемент, стоящий перед key, больше, происходит обмен
                {                              
                    list[j + 1] = list[j];     
                    j = j - 1;
                }

                list[j + 1] = key; //вставка элемента
            }

            return list;
        }

        //Сортировка выбором
        static List<int> SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i; //индекс наименьшего элемента

                for (int j = i + 1; j < list.Count; j++) //поиск наименьшего элемента
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                Swap(list[i], list[min]); //обмен местами наименьшего элемента, который еще не был добавлен в 
            }                             //отсортированную часть массива, с первым в неотсортированной части

            return list;
        }

        //Пузырьковая сортировка
        static List<int> BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++) //просмотр пар соседних элементов массива
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[i]) //в случае, если элементы пары находятся в неправильно порядке
                    {                      //выполняется функция их обмена местами
                        Swap(list[i], list[j]);
                    }
                }
            }
            return list;
        }
    }
}
