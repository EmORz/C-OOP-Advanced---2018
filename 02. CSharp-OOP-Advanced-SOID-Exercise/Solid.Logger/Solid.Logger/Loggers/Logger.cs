
using Solid.Logger.Appenders;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Loggers
{
    using Contracts;
    using Solid.Logger.Appenders.Contracts;
    using System;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender): this(consoleAppender)
        {
         
            this.fileAppender = fileAppender;

        }
        public void Error(string format, string errorMessage)
        {
            AppendMessage(format,ReportLevel.Error, errorMessage);
        }


        public void Info(string format, string infoMessage)
        {
            AppendMessage(format, ReportLevel.Info, infoMessage);
        }

        public void Warning(string format, string infoMessage)
        {
            AppendMessage(format, ReportLevel.Warning, infoMessage);
        }


        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.Fatal, fatalMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.Critical, criticalMessage);
        }


        private void AppendMessage(string format, ReportLevel type, string errorMessage)
        {
            fileAppender?.Append(format,type, errorMessage);
            consoleAppender?.Append(format, type, errorMessage);
        }
    }
}
