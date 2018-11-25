namespace Solid.Logger.Appenders.Factory
{
    using Contracts;
    using Loggers;
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System;
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
                    return new FileAppender(layout, new LogFile());
                default:
                    throw  new ArgumentException("Invalid appender type!");
            }
        }
    }
}
