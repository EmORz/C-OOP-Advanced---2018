

namespace _4.GenericSwapMethodIntegers
{
    using _3.GenericSwapMethodStrings;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO just use code from previus task :)
            List<int> messages = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                messages.Add(input);

            }

            int[] indexec = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Box<int> value = new Box<int>(messages);
            value.Swap(indexec[0], indexec[1]);
            Console.WriteLine(value);
        }
    }
}
