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
            if (inputParameters.Count == 0)
            {
                Environment.Exit(0);

            }
            string command = inputParameters[0];
            if (command == string.Empty)
            {
                Environment.Exit(0);
            }
            if (command == string.Empty)
            {
                Environment.Exit(0);
            }
            inputParameters.RemoveAt(0);

            string result = string.Empty;

            MethodInfo methodInfo;


            if (command == "Vehicle" || command == "Part")
            {
                methodInfo = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == "Add" + command);

            }
            else
            {
                methodInfo = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name == command);
            }



            //switch (command)
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
            result = (string)methodInfo.Invoke(tankManager, new object[] { inputParameters });
            return result;
        }
    }
}