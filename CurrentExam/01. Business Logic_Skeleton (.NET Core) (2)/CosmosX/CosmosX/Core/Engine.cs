using System.Collections.Generic;
using System.Text;
using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = true;
        }

        public void Run()
        {
            StringBuilder sb = new StringBuilder();
            while (isRunning)
            {
                var input = reader.ReadLine();
                if (input == "Exit")
                {
                    isRunning = false;
                }
                List<string> inputArgs = new List<string>(input.Split());
                var command = commandParser.Parse(inputArgs);
                sb.AppendLine(command);
                writer.WriteLine(command);

            }
            //writer.WriteLine(sb.ToString());


        }
    }
}