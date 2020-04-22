using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class NOD 
    {
        //Метод GCD1 - метод определения НОД двух чисел, основывающийся
        //на том, что алгоритм должен возвращать наибольшее целое число, которое
        //делится без остатка на оба числа, являющихся входными данными.
        public static int GCD1(int m, int n)
        {
            while (m != 0 && n != 0)
            {
                if (m >= n)
                    m = m % n;
                else
                    n = n % m;
            }
            return m + n;
        }

        //Метод GCD2 - метод определения НОД двух чисел путём получения их простых множителей, 
        //нахождения всех общих множителей и их дальнейшего перемножения.
        public static int GCD2(int m, int n)
        {
            int nod = 1; //НОД чисел m и n

            if (m != 0 && n != 0)  
            {                     

                List<int> primesM = FindPrimes(m); //простые множители числа m
                List<int> primesN = FindPrimes(n); //простые множители числа n
                List<int> final = new List<int>(); //общие простые множители чисел m и n

                for (int i = 0; i < primesM.Count; i++) //нахождение общих простых множителей чисел m и n
                {
                    for (int j = i; j < primesN.Count; j++)
                    {
                        if (primesN[j] == primesM[i])
                        {
                            final.Add(primesN[j]);
                        }
                        break;
                    }
                }


                foreach (int f in final) //перемножение всех общих простых множителей чисел m и n
                    nod *= f;
            }
            else
                throw new Exception("Вы ввели неположительное число!");

            return nod;
        }

        public static List<int> FindPrimes(int n) //Метод нахождения простых множителей числа n
        {
            ArrayList primes = Resheto(n);    //получение всех простых чисел в диапазоне от 1 до n с помощью метода Resheto()
            List<int> res = new List<int>();  //массив простых множителей числа n

            while (n != 1) 
            {
                for (int i = 0; i < primes.Count; i++)
                {
                    while (n % (int)primes[i] == 0) //До тех пор, пока число n делится без остатка на простой множитель primes[i],
                    {                               //оно добавляется в массив простых множителей res, а затем n присваивается 
                        res.Add((int)primes[i]);    //целая часть от деленя на этот простой множитель.
                        n = n / (int)primes[i];
                    }
                }
            }

            return res;
        }

        public static ArrayList Resheto(int n) //Решето Эратосфена - алгоритм нахождения всех простых чисел на отрезке от 1 до n
        {
            bool[] prime = new bool[n+1]; //Логический массив, в котором будет храниться информация о том, 
                                          //является число на отрезке от 1 до n простым или составным.
            for (int i = 2; i <= n; i++)  //Первоначально все числа на отрезке от 2 до n помечаются, как простые
                prime[i] = true;

            for (int i = 2; i <= n; i++)  //Процесс определения составных чисел
            {
                if (prime[i])
                {
                    if (i * 1L * i <= n)
                        for (int j = i * i; j <= n; j += i)
                            prime[j] = false;
                }
            }

            ArrayList primeNumbers = new ArrayList(); //массив, содержащий простые числа на отрезке от 1 до n

            for (int i = 0; i < n; i++)
                if (prime[i] == true)     //Если значение в массиве prime истинно, то есть в случае, когда число
                    primeNumbers.Add(i);  //в массиве - простое, оно добавляеется в массив primeNumbers.

            return primeNumbers;
        }
    }
}
