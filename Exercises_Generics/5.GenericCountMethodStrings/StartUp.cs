using System.Collections.Generic;
using System.Linq;
using _3.GenericSwapMethodStrings;

namespace _5.GenericCountMethodStrings
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<double> messages = new List<double>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                messages.Add(input);

            }

            var elements = double.Parse(Console.ReadLine());
            Box<double> value = new Box<double>(messages);
            double result = value.GetGreater(elements);
            Console.WriteLine(result);
        }
    }
}
