using System;
using System.Linq;
using Problem_9_LinkedListTraversal.Models;

namespace Problem_9_LinkedListTraversal.Core
{
    public class Engine
    {
        public void Run()
        {
            LinkedList<int>  list = new LinkedList<int>();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split()
                    .ToArray();
                string command = tokens[0];
                var number = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(number);
                        break;
                    case "Remove":
                        list.Remove(number);
                        break;
                        ;
                }
            }

            Console.WriteLine(list.Count);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
