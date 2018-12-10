using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 4;
            string number = "4";
            string numToText = num.ToString();
            int stringToInt = int.Parse(number);

            var text = "some text";

            for (int i = 0; i < text.Length; i++)
            {
                int temp = text[i];
                Console.Write("ASCII => ");
                Console.WriteLine(temp);
            }
            Console.WriteLine("numToText =>"+numToText);
            Console.WriteLine("stringToInt =>" + stringToInt);
        }
    }
}
