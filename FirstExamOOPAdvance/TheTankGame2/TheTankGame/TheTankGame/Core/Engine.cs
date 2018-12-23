using System.Collections.Generic;

namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                var input = reader.ReadLine();

                if (input == "Terminate")
                {
                    isRunning = false;
                    break;
                }

                var temp = this.commandInterpreter.ProcessInput(new List<string>(input.Split()));
                writer.WriteLine(temp.Trim());
            }
            var temp1 = this.commandInterpreter.ProcessInput(new List<string>{"Terminate"});
            writer.WriteLine(temp1.Trim());
        }
    }
}