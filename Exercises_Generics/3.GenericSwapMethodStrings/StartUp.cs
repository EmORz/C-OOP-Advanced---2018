
namespace _3.GenericSwapMethodStrings
{
    using System.Collections.Generic;
    using System.Linq;

    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                messages.Add(input);

            }

            int[] indexec = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Box<string> value = new Box<string>(messages);
            value.Swap(indexec[0], indexec[1]);
            Console.WriteLine(value);



        }
    }
}
