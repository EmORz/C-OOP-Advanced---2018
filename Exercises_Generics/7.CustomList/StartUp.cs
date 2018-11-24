using System.Linq;

namespace _7.CustomList
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ISoftUniList<string> softUniList = new SoftUniList<string>();

            /*•	Add <element> - Adds the given element to the end of the list
              •	Remove <index> - Removes the element at the given index
              •	Contains <element> - Prints if the list contains the given element (True or False)
              •	Swap <index> <index> - Swaps the elements at the given indexes
              •	Greater <element> - Counts the elements that are greater than the given element and prints their count
              •	Max - Prints the maximum element in the list
              •	Min - Prints the minimum element in the list
              •	Print - Prints all of the elements in the list, each on a separate line
              •	END - stops the reading of commands
              */

            var input = Console.ReadLine();

            while (input!="END")
            {
                var inputArgs = input.Split();
                var commands = inputArgs[0];
                var tokens = inputArgs.Skip(1).ToArray();

                var elements = "";
                switch (commands)
                {
                    case "Add":
                        var element = tokens[0];
                        softUniList.Add(element);
                        break;
                    case "Remove":
                        var index = int.Parse(tokens[0]);
                        softUniList.Remove(index);
                        break;
                    case "Contains":
                        elements = (tokens[0]);
                        Console.WriteLine(softUniList.Contains(elements));
                        break;
                    case "Swap":
                        var index1 = int.Parse(tokens[0]);
                        var index2 = int.Parse(tokens[1]);
                        softUniList.Swap(index1, index2);
                        break;
                    case "Greater":
                        elements = (tokens[0]);
                        Console.WriteLine(softUniList.CountGreaterThan(elements));
                        break;
                    case "Max":
                        Console.WriteLine(softUniList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(softUniList.Min());
                        break;
                    case "Sort":
                        softUniList.Sort();
                        break;
                    case "Print":
                        foreach (var item in softUniList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }






                input = Console.ReadLine();
            }
        }
    }
}
