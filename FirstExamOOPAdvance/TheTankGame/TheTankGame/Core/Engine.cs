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
                PrintResult(input);

            }
            string terminateResult = this.commandInterpreter.ProcessInput(new List<string> { "Terminate" });
            this.writer.WriteLine(terminateResult);


        }

        private void PrintResult(string input)
        {
            List<string> inputArgs = new List<string>(input.Split());

            var result = "";
            result = this.commandInterpreter.ProcessInput(inputArgs);

            writer.WriteLine(result.Trim());
        }
    }
}