using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1
            Console.WriteLine("*** Нахождение наибольшего целого числа в массиве ***");
            int[] mass = {0, 8, 87, 9, -2, 4, 56, 1, 1};
            Console.WriteLine(FindMax(mass));

            // Task2
            Console.WriteLine("\n*** Вычисление суммы первых n натуральных чисел ***");
            Console.WriteLine(SummN(5)/(double)SummN(8));

            // Task3
            Console.WriteLine("\n*** Нахождение НОД двух чисел ***");
            Console.WriteLine(NOD(140, 96));
            Console.WriteLine(NOD(84, 90));

            // Task4     
            Console.WriteLine("\n*** Перевод целого числа в двоичную систему ***");
            Console.WriteLine(Converter(121));

            //Task5
            Console.WriteLine("\n*** Сравнение двух строк ***");
            string s1 = "афыs";
            string s2 = "афыk";
            Console.WriteLine(Comparator(s1, s2, s1.Length - 1));
        }

        //Нахождение наибольшего целого числа в массиве по приведенному словесному описанию
        //(вместо псевдокода)
        public static int FindMax(int[] mass)
        {
            int largest = mass[0]; //2 простейшие операции - индексация массива 
                                   //и приваивание переменной значения

            for (int i = 1; i < mass.Length; i++) //В начале выполения цикла счётчик i получает значение 1 - 1 простейшая операция, 
                                                  //затем проверяется условие i < mass.Length. Сравнение происходит n раз, т.о
                                                  //к кол-ву простейших операций добавляется n.
                if (largest < mass[i])            //Тело цикла выполняется n>=1 раз. При каждой итерации - 4 или 6 простейших операции                   
                    largest = mass[i];            //в зависимости от выполнения или невыполнения условия if. В итоге, к кол-ву простейших
                                                  //операций добавляется 4(n-1) или 6(n-1) операций.
            return largest;
        }
        //Итого: T(n)min = 2 + 1 + n + 4(n-1) + 1 = 5n; T(n)max = 2 + 1 + n + 6(n-1) + 1 = 7n - 2.
        //Алгоритм все элементы массива один раз, поэтому его сложность равна O(n).

        //Метод вычисления суммы первых n натуральных чисел
        public static int SummN(int n)
        {
            while(n != 0) //до тех пор, пока n не станет равных нулю, будем 
            {             //прибавлять к нему число, меньшее на единицу
                return n + SummN(n - 1);
            }

            return 0;
        }

        //Рекурсивный метод, возвращающий НОД двух чисел
        public static int NOD(int m, int n)
        {
            if (n == 0)             //Выполнение метода заканчивается, когда остаток
                return Math.Abs(m); //от деления m на n становится равным нулю.
            else
                return NOD(n, m % n);
        }

        public static StringBuilder s = new StringBuilder(); //объект класса StringBuilder, в который записывается 
                                                             //результат перевода числа в двоичную систему

        //Рекурсивный метод, осуществляющий перевод целого числа в двоичную систему
        public static StringBuilder Converter(int n)
        {
            if (n == 0)   //Выполнение метода осуществляется до тех пора, пока число n
                return s; //не станет равным нулю
            else
            {
                Converter(n / 2);
                return s.Append(n % 2);
            }
        }

        //Рекурсивный метод, сравнивающий две строки
        public static bool Comparator(string s1, string s2, int n) //метод получает на вход сравниваемые строки и номер текущей позиции символов строк,
        {                                                          //первоначально она равна s1.Length - 1, т.е строки сравниваются с конца
            if (s1.Length != s2.Length) //если длины строк различны, они не равны
                return false;

            if (n == 0)  //если метод дошел до последнего символа строк, он завершается
                return true;
            else if (s1[n] == s2[n]) //иначе, если текущие символы строк равны, метод вызывается рекурсивно
            {
                return Comparator(s1, s2, n - 1);
            }
            else //иначе строки не равны
                return false;
        }
    }
}
