using System;
using System.Linq;

namespace Problem_3_Stack.Core
{
    public class Engine
    {
        public void Run()
        {
            Models.Stack<int> stack = new Models.Stack<int>();

            string input;

            while ((input = Console.ReadLine())!="END")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        int[] elements = tokens.Skip(1)
                            .Select(x => x.Split(',').First())
                            .Select(int.Parse)
                            .ToArray();
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {

                    Console.WriteLine(element);

                }
            }
 

        }
    }
}
