using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Console.WriteLine("\n*** Нахождение простых множителей для целого числа прямым методом ***");
            foreach (int n in FindPrimeFactorsV1(28))
            Console.WriteLine(n);

            //Task2
            Console.WriteLine("\n*** Нахождение простых множителей для целого методом преобразования ***");
            foreach (int n in FindPrimeFactorsV1(28))
            Console.WriteLine(n);
        }

        //Task1 - нахождение простых множителей для целого числа прямым методом (Временная асимпотическая сложность алгоритма: О(n))
        static List<int> FindPrimeFactorsV1(int n)
        {
            List<int> factors = new List<int>(); //список простых множителей числа
            int i = 2;

            while (i < n) //делим исходное число n на все числа в интервале от двух до n
            {
                while (n % i == 0) //если число делится на i без остака, 
                {                  //добавляем его в список простых
                    factors.Add(i);
                    n = n / i;     //и присваиваем числу n результат деления на i
                }

                i++; //проверяем следующий множитель
            }

            if (n > 1) //если в результате получился остаток, то он - тоже множитель
                factors.Add(i);

            return factors;
        }

        //Task2 - нахождение простых множителей для целого числа методом преобразования (Временная асимпотическая сложность алгоритма: О(sqrt(n))
        static List<int> FindPrimeFactorsV2(int n)
        {
            List<int> factors = new List<int>();

            while (n % 2 == 0) //проверка делимости числа на 2
            {
                factors.Add(2);
                n = n / 2;
            }

            int i = 3; //поиск нечетных множителей числа
            int maxFactor = (int)Math.Sqrt(n); //максимальный простой множитель - квадратный корень из n

            while(i <= maxFactor)
            {
                while (n % i == 0)                 //если число делится на i без остака, 
                {                                  //добавляем его в список простых
                    factors.Add(i);
                    n = n / i;                     //и присваиваем числу n результат деления на i
                    maxFactor = (int)Math.Sqrt(n); //устанавливаем новыю верхнюю границу
                }
                i += 2; //проверка следующего нечетного множителя
            }

            if (n > 1)  //если в результате получился остаток, то он - тоже множитель
                factors.Add(n);

            return factors;
        }
    }
}
