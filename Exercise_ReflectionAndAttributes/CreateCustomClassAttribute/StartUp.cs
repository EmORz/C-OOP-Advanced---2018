using System;


class StartUp
{
    static void Main(string[] args)
    {
        var classType = typeof(Weapon);
        var attributes = classType.GetCustomAttributes(false);

        foreach (var attribute in attributes)
        {
            if (attribute is ClassAttribute classAtr)
            {
                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {classAtr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {classAtr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Description: {classAtr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {string.Join(", ", classAtr.Reviewers)}");
                            break;

                    }
                }
            }
        }
    }
}

