using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    class Program
    {
        //Проверка всех заданий
        static void Main(string[] args)
        {
            //Task1 
            String str1 = "[()[]()][]"; // Тестовая последовательность символов
            Console.WriteLine(str1);

            Bracket B = new Bracket(str1); // Объект для контроля последовательности символов

            String str2 = "[()[]()][])"; // Тестовая последовательность символов
            Console.WriteLine(str2);

            Bracket B2 = new Bracket(str2); // Объект для контроля последовательности символов

            String str3 = "(["; 
            Console.WriteLine(str3);

            Bracket B3 = new Bracket(str3); 

            String str4 = "([)]"; 
            Console.WriteLine(str4);

            Bracket B4 = new Bracket(str4);

            String str5 = "([([()])])";
            Console.WriteLine(str5);

            Bracket B5 = new Bracket(str5);

            isValid(B);
            isValid(B2);
            isValid(B3);
            isValid(B4);
            isValid(B5);

            //Task2
            string s = "У на4с в кварти77ре живёт 3 кошки 3 соба8ки и 4 попугая";
            Console.WriteLine("\n" + StringFormatting.MakeNewString(s) + "\n");

            //Task3
            Dictionary.MakeDictionary("Ты – мой май , что так и не настал , " +
                "Ты – мечта , мой грех несовршённый , " +
                "Ты – души цветущий краснотал , " +
                "Ты – мой нерв , что страстью оголённый . " +
                "Ты – небес нахмуренная бровь , " +
                "Ты – судьбы безмерная жестокость , " +
                "Юных грёз безгрешная любовь ... " +
                "Боль моя и сердца одинокость .");

            Dictionary.PrintDictionary();
        }

        private static void isValid(Bracket B)
        {
            if (B.Bracket_Control())
                Console.WriteLine("Баланс скобок {0} соблюдается.", B.Input);
            else
                Console.WriteLine("Баланс скобок {0} не соблюдается.", B.Input);
        }
    }
}
