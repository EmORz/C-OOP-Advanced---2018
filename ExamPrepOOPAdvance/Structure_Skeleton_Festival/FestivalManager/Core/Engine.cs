
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning = true;
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = reader.ReadLine();

                if (input == "END")
                {
                    this.isRunning = false;
                    continue;
                }
                var result = "";
                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (TargetInvocationException ex)
                {
                    result = "ERROR: "+ex.InnerException.Message;
                }
                catch (Exception ex) 
                {
                    result = "ERROR: " + ex.Message;
                }
                this.writer.WriteLine(result);

            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split();

            var command = tokens[0];
            var args = tokens.Skip(1).ToArray();


            string result = "";

            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                var festivalControlerMethod = this.festivalCоntroller.GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == command);

                result = (string)festivalControlerMethod.Invoke(this.festivalCоntroller, new object[] { args });
            }
          
            return result;
        }
    }
}