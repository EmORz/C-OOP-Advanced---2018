using System.Text;

namespace Problem_2_Collection.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            //TODO add implementation
            ListyIterator<string> listyIterator = null;

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(command.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HashNext());
                        break;
                    case "PrintAll":
                        StringBuilder sb = new StringBuilder();
                        foreach (var element in listyIterator)
                        {
                            sb.Append(" " + element);
                        }
                        Console.WriteLine(sb.ToString().Trim());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);

                        }

                        break;
                }
            }
        }
    }
}