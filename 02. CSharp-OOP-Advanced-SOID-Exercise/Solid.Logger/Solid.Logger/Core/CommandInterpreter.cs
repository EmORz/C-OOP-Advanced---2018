namespace Solid.Logger.Core
{
    using Appenders.Factory;
    using Contracts;
    using Layouts.Factory;
    using Loggers.Enum;
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Appenders.Factory.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Layouts.Factory.Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter:ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppendFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout );
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0], true);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
                
            }
        }

        public void Print()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender); 
            }
        }
    }
}
