using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    class Bracket
    {
        public String Input { get; set; }
        public int[] Coded { get; set; }

        public Bracket(String s)
        {
            Input = s;
            Coded = new int[Input.Length];
        }

        // Кодирование последовательности открывающихся и закрывающихся скобок
        public void Coder()
        {
            for (int j = 0; j < Input.Length; j++)
                switch (Input[j])
                {
                    case '(': { Coded[j] = 1; break; }
                    case ')': { Coded[j] = -1; break; }
                    case '[': { Coded[j] = 2; break; }
                    case ']': { Coded[j] = -2; break; }
                    default: break;
                };
        }

        // Контроль баланса скобок
        public bool Bracket_Control()
        {
            Stack St = new Stack();     // Стек для хранения закодированной послед-ти
            int i = 0; int t;
            Boolean er = false;         // Признак соблюдения баланса скобок
            Coder();                    // Кодирование исходной последовательности символов

            // Пока последовательность не окончена и ошибка не обнаружена
            while ((i < Input.Length) && (er == false))
            {
                // Если обнаружена открывающаяся скобка, занести ее в стек
                if ((Coded[i] == 1) || (Coded[i] == 2))
                    St.Push(Coded[i]);
                // Если обнаружена закрывающаяся скобка, проверить состояние стека
                else
                {
                    if (St.isEmpty())
                    {
                        er = true;    // Если стек пуст, зафиксировать ошибку
                    }
                    else
                    {
                        // Иначе - вытолкнуть из стека открывающуюся скобку
                        t = St.Pop();
                        // Если открывающаяся скобка не соответствует закрывающейся скобке,
                        // зафиксировать ошибку
                        er = (t != (-Coded[i]));
                    }
                }
                i++;
            }

            // Ошибка не обнаружена, если все закрывающиеся скобки соответствуют
            // открывающимся скобкам и стек пуст
            er = ((er == false) && (St.Top == null));
            return er;
        }
    }
}
