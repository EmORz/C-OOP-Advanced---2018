using System;
using System.Linq;
using System.Reflection;

namespace TheTankGame.Core
{
    using System.Collections.Generic;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string commandName = inputParameters[0];
            if (commandName == string.Empty)
            {
                Environment.Exit(0);
            }
            inputParameters.RemoveAt(0);

            string result = string.Empty;
            MethodInfo command;

            if (commandName == "Vehicle" || commandName == "Part")
            {
                command = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == "Add" + commandName);
            }
            else
            {
                command = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == commandName);
            }

            result = (string)command.Invoke(tankManager, new object[] {inputParameters});
            //switch (commandName)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddPart(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            return result;
        }
    }
}