namespace _1.GenericBoxOfString
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
                Console.WriteLine(new Box<int>(text));
            }
        }
    }
}
