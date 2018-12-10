using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core
{
    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + "Command";
            Type typeOfCommand = Type.GetType("_03BarracksFactory.Core.Command." + commandName);

            IExecutable command = (IExecutable)Activator.CreateInstance(typeOfCommand, new object[] {data});
            //
            var fieldsToInject = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes(false)
                    .Any(ca => ca.GetType()== typeof(CustomAttributes.InjectAttribute)));

            foreach (var commandField in fieldsToInject)
            {
                var engineClassFieldValue = typeof(Engine)
                    .GetField(commandField.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this);
                commandField.SetValue(command, engineClassFieldValue);
            }
 
            result = command.Execute();
            return result;
        }
    }
}
