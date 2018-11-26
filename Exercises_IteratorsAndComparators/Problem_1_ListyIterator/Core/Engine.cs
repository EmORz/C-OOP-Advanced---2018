namespace Problem_1_ListyIterator.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
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
