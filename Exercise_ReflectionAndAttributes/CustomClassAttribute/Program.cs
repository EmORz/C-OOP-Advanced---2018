namespace CustomClassAttribute
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var temp = "";
                InfoAttribute info =
                    (InfoAttribute) Attribute.GetCustomAttribute(typeof(Weapon), typeof(InfoAttribute));
                switch (input)
                {

                    case "Author":
                        temp = $"Author: {info.Author}";
                        break;
                    case "Revision":
                        temp = $"Revision: {info.Revision}";
                        break;
                    case "Description":
                        temp = $"Class description: {info.Description}";
                        break;
                    case "Reviewers":
                        temp = $"Reviewers: {String.Join(", ", info.Reviewers)}";
                        break;
                }
                Console.WriteLine(temp);
                input = Console.ReadLine();
            }
        }
    }
}
