using System;
using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            //TODO put your reflection code here
            //Take data from class
            Type classType = typeof(BlackBoxInteger);
            //create instance
            var instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            string input = Console.ReadLine();


            while (input != "END")
            {
                string[] tokens = input.Split("_").ToArray();
                string command = tokens[0];
                int value = int.Parse(tokens[1]);

                //get method
                classType.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Invoke(instance, new object[]{value});
                //get fields
                int result =  (int)classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(instance);
                input = Console.ReadLine();
                Console.WriteLine(result);
            }

            //Take data from class
            // create instance of class

        }
    }
}
