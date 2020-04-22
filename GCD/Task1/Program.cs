using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args) //Проверка работы методов GCD1 и GCD2
        {
            try
            {
                Console.WriteLine("*** Определение НОД (Вариант - 1) ***");
                Console.WriteLine(NOD.GCD1(15, 28));
                Console.WriteLine(NOD.GCD1(140, 96));
                Console.WriteLine(NOD.GCD1(27, 9));
                Console.WriteLine(NOD.GCD1(84, 90));
                Console.WriteLine("*** Определение НОД (Вариант - 2) ***");
                Console.WriteLine(NOD.GCD2(15, 28));
                Console.WriteLine(NOD.GCD2(140, 96));
                Console.WriteLine(NOD.GCD2(27, 9));
                Console.WriteLine(NOD.GCD2(84, 90));
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
