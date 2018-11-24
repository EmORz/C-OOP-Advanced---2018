namespace _10.Tuple
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] personalInfo = Console.ReadLine().Split();

            var fullName = personalInfo[0] + " " + personalInfo[1];
            var neghberhoods = personalInfo[2];
            var town = personalInfo[3];

            string[] beerInfo = Console.ReadLine().Split();
            var name = beerInfo[0];
            var amountBeer = int.Parse(beerInfo[1]);
            var drunkOrNot = beerInfo[2] == "drunk"?true:false;

            string[] specialNumber = Console.ReadLine().Split();
            var nameP = (specialNumber[0]);
            var accountBalance = double.Parse(specialNumber[1]);
            var bankName = specialNumber[2];

            //

            SpecialTuple<string, string, string> personalTuple = new SpecialTuple<string, string, string>(fullName, neghberhoods, town);
            SpecialTuple<string, int, bool> beerTuple = new SpecialTuple<string, int, bool>(name, amountBeer, drunkOrNot);
            SpecialTuple<string, double, string> specialTupleTuple = new SpecialTuple<string, double, string>(nameP, accountBalance, bankName);

            Console.WriteLine(personalTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTupleTuple);






        }
    }
}
