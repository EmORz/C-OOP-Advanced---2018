
namespace _2.GenericBoxOfInteger
{
    using System;
    using _1.GenericBoxOfString;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO in this case just reuse code from 1.GenericBoxOfString
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
                Console.WriteLine(new Box<int>(text));
            }
        }
    }
}
