using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            //TODO put your reflection code here.
            Type classType = typeof(BlackBoxInteger);

            var instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            string command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split("_").ToArray();
                var methodName = tokens[0];
                var value = int.Parse(tokens[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(instance, new object[] {value});
                var currentValue = classType
                    .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .GetValue(instance);
                Console.WriteLine(currentValue);
                command = Console.ReadLine();
            }
        }
    }
}
