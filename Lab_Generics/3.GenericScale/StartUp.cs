namespace GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var test = new Scale<string>("Desi", "Emo");

            var resul = test;
            Console.WriteLine(resul.GetHeavier());
        }
    }
}
