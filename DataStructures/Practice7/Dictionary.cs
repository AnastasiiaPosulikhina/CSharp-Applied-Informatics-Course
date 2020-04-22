using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    class Dictionary
    {
        public static List<string> dictionaryWords = new List<string>(); //список слов в словаре
        public static List<int> wordFrequency = new List<int>();         //спсиок часто встречающихся в тексте слов
        //Метод создания словаря
        public static void MakeDictionary(string text)
        {
            string[] textWords = text.Split(new char[] { ' ' }); //массив слов, полученный из исходного текста
            Array.Sort(textWords); //отсортированный в алфавитном порядке массив слов
            int index = 0; 

            for(int i = 0; i < textWords.Length; i++)
            {
                if(!dictionaryWords.Contains(textWords[i])) //если список слов не содержит какое-либо слово из массива,
                {
                    dictionaryWords.Add(textWords[i]);      //то оно добавляется в список,
                    wordFrequency.Insert(index, 1);         //получает соответсвубщий индекс и счетчик частоты появления этого слова становится равным 1
                    index++;                                //увеличение индекса на единицу для добавления следующего слова 
                }
                else                                        //иначе счетчик частоты появления слова увеличивается на 1
                {
                    wordFrequency[dictionaryWords.IndexOf(textWords[i])] += 1;
                }
            }
        }

        //Метод вывода словаря на экран
        public static void PrintDictionary()
        {
            for(int i = 0; i < dictionaryWords.Count; i++)
            {
                Console.WriteLine(dictionaryWords[i] + " - " + wordFrequency[i]);
            }
        }
    }
}
