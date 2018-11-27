using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem_6_StrategyPattern.Comparator;
using Problem_6_StrategyPattern.Models;
namespace Problem_6_StrategyPattern.Core
{
    public class Engine
    {
        public void Run()
        {
            //Comparators
            SortedSet<Person> sortAge = new SortedSet<Person>(new AgeComparator());
            SortedSet<Person> sortName = new SortedSet<Person>(new NameComparator());
            //
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                sortAge.Add(person);
                sortName.Add(person);
            }
            foreach (var name in sortName)
            {
                Console.WriteLine(name);
            }
            foreach (var age in sortAge)
            {
                Console.WriteLine(age);
            }
        }
    }
}
