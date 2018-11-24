using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Core.Contracts;

namespace Solid.Logger.Core
{
    public class Engine:IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = new CommandInterpreter();
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
                var tokens = input.Split("|");
                this.commandInterpreter.AddMessage(tokens);
                input = Console.ReadLine();
            }
            this.commandInterpreter.Print();


        }
    }
}
