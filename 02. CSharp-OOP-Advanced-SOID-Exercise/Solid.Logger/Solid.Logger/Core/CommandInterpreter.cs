﻿using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Appenders.Factory;
using Solid.Logger.Appenders.Factory.Contracts;
using Solid.Logger.Core.Contracts;
using Solid.Logger.Layouts;
using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Layouts.Factory;
using Solid.Logger.Layouts.Factory.Contracts;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Core
{
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
            ReportLevel reportLevel = ReportLevel.Info;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2], true);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout );
            appender.ReportLevel = reportLevel;
            appenders.Add(appender);
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
    }
}
