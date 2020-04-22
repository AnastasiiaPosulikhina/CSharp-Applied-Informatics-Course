using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    class StringFormatting
    {
        public static string MakeNewString(string s)
        {
            Queue<char> words = new Queue<char>();          //очередь, содержащая символы исходной строк, кроме цифер
            Queue<char> numbers = new Queue<char>();        //очередь, содержащая цифры исходной строк
            StringBuilder newString = new StringBuilder();  //новая строка

            for(int i = 0; i < s.Length; i++) //проход по всем символам исходной строки
            {
                if(!char.IsNumber(s[i]))      //если символ строки не является цифрой, то
                    words.Enqueue(s[i]);      //выполняется его добавление в очередь words
                else
                    numbers.Enqueue(s[i]);    //иначе - в очередь numbers
            }

            foreach (char c in words)         //добавление всех символов из очереди words
                newString.Append(c);          //в новую строку

            foreach (char n in numbers)       //добавление всех цифер из очереди numbers
                newString.Append(n);          //в новую строку

            return newString.ToString();
        }
    }
}
