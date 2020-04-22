using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Node       // Класс "Элемент стека"
    {
        public int Info { get; set; }
        public Node Next { get; set; }

        public Node() { }

        public Node(int info, Node next)
        {
            Next = next;
            Info = info;
        }
    }

    public class Stack
    {
        public Node Top { get; set; }
        private List<Node> items;

        // Конструктор: создание пустого стека
        public Stack()
        {
            items = new List<Node>();
        }

        // Занесение элемента в стек
        // info - значение,заносимое в верхушку стека
        public void Push(int info)
        {
            Top = new Node(info, new Node());
            items.Add(Top);
        }

        // Выталкивание элемента из стека
        // x - значение, извлекаемое из верхушки стека
        public int Pop()
        {
            Node x = items.LastOrDefault();

            if (x == null)
                Console.WriteLine("Стек пуст.");

            items.RemoveAt(items.Count - 1);
            Top = null;

            return x.Info;
        }


        public bool isEmpty() // True, если стек пуст
        {
            if (items.Count == 0)
                return true;
            else
                return false;
        }
    }
}
