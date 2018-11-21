using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Appenders.Factory.Contracts;
using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Loggers;

namespace Solid.Logger.Appenders.Factory
{
    public class AppendFactory: IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLowercase = type.ToLower();

            switch (typeToLowercase)
            {
                case "consoleappender":
                    return  new ConsoleAppender(layout);
                case "fileappender":
                    return new Appender(layout, new LogFile());
                default:
                    throw  new ArgumentException("Invalid appender type!");
            }
        }
    }
}
