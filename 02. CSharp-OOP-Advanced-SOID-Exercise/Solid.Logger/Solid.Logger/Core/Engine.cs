
namespace Solid.Logger.Core
{
    using Contracts;
    using Solid.Logger.Appenders.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine:IEngine
    {
        private ICollection<IAppender> appenders;

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.appenders = new List<IAppender>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(inputArgs);
            }

            var input = Console.ReadLine();

            while (input!="END")
            {
                var tokens = input.Split('|');
                this.commandInterpreter.AddMessage(tokens);
                input = Console.ReadLine();
            }
            this.commandInterpreter.Print();


        }
    }
}
