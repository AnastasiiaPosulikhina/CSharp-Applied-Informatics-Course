using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass1 = {3, 6, 9, 12, 0, -4, 5, 67};
            Array.Sort(mass1);
            Array.Reverse(mass1); //массив 1, упорядоченный по убыванию чисел

            int[] mass2 = {5, 8, -23, 67, 3, 12, 4, 55};
            Array.Sort(mass2);
            Array.Reverse(mass2); //массив 2, упорядоченный по убыванию чисел

            Console.WriteLine("Элементы массива 1:");
            foreach (int n in mass1)
                Console.Write(n + " ");

            Console.WriteLine("\nЭлементы массива 2:");
            foreach (int n in mass2)
                Console.Write(n + " ");

            Console.Write("\nВведите искомый элемент: ");
            try
            {
                int k = Convert.ToInt32(Console.ReadLine());
                int res = FindMaxIndex(k, mass1, mass2);

                if (res == 1)
                    Console.WriteLine($"Элемент {k} имеет наибольший номер в первом массиве.");
                else if (res == 2)
                    Console.WriteLine($"Элемент {k} имеет наибольший номер во втором массиве.");
                else if (res == -1)
                    Console.WriteLine("Данного элемента нет хотя бы в одном массиве.");
                else
                    Console.WriteLine($"Индекс элемента {k} в первом массиве равен индексу во втором.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        //Метод определения массива, в котором выбранный пользователем элемент имеет наибольший номер
        static int FindMaxIndex(int k, int[] mass1, int[] mass2)
        {
            Array.Reverse(mass1); //для работы с методом бинарного поиска необходимо отсортировать массивы по возрастанию
            Array.Reverse(mass2);
            int index1 = BinarySearch(k, mass1); //вызов метода бинарного поиска
            int index2 = BinarySearch(k, mass2);

            if (index1 == -1 || index2 == -1) //если искомого элемента нет в массиве, возвращается -1 
                return -1;
            else if (index1 > index2)        //иначе, если номер искомого элемента в отсортированном по возрастанию
                return 2;                    //массиве 1 больше, чем в массиве 2, то вернуть 2
            else if (index1 < index2)        //иначе, если номер искомого элемента в отсортированном по возрастанию
                return 1;                    //массиве 2 больше, чем в массиве 1, то вернуть 1
            else                             //иначе вернуть 0
                return 0;                   
        }

        //Метод бинарного поиска
        static int BinarySearch(int n, int[] mass)
        {
            int min = 0;                //левая граница массива
            int max = mass.Length - 1;  //правая граница массива

            while (min <= max) //до тех пор, пока индекс левой границы массива либо меньше, либо равен индексу правой
            {
                int mid = (min + max) / 2; //осуществляется поиск середины массива

                if (mass[mid] < n)         //в случае, если значение по этому индексу меньше искомого    
                    min = mid + 1;         //сдвигаем левую границу массива
                else if (mass[mid] > n)    //иначе, если значение по этому индексу больше искомого
                    max = mid - 1;         //сдвигаем правую границу массива
                else                       //иначе, возвращаем индекс
                    return mid;
            }

            return -1; //если искомого элемента нет в массиве, возвращается -1
        }
    }
}
