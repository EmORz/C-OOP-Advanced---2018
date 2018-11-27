using Problem_4_Froggy.Models;
using System;
using System.Linq;

namespace Problem_4_Froggy.Core
{
    public class Engine
    {
        public void Run()
        {

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake<int> stones = new Lake<int>(input);
            Console.WriteLine(string.Join(", ", stones));




        }
    }
}
