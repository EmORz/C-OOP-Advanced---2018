using System;
using System.Collections.Generic;
using System.Linq;
using Problem_5_ComparingObjects.Models;

namespace Problem_5_ComparingObjects.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Person> peopleList = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split().ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];
                peopleList.Add(new Person(name, age, town));
            }

            var controlNumber = int.Parse(Console.ReadLine())-1;

            Person person = peopleList[controlNumber];

            int numEqual = 0;
            int notEqual = 0;


            foreach (var man in peopleList)
            {
                if (man.CompareTo(person) == 0)
                {
                    numEqual++;
                }
                else
                {
                    notEqual++;
                }
            }

            var totalPeople = numEqual + notEqual;

            if (numEqual>1)
            {
                Console.WriteLine($"{numEqual} {notEqual} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
