using Solid.Logger.Core;
using Solid.Logger.Core.Contracts;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger
{
    using Solid.Logger.Appenders;
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers.Contracts;
    using Solid.Logger.Loggers;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();




        }
    }
}
