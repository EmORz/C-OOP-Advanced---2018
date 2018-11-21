

using System;
using Solid.Logger.Loggers.Contracts;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Appenders
{
    using Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System.IO;

    public class Appender : IAppender
    {
        private const string path = "../../../log.txt";
        private readonly ILayout layout;
        private readonly ILogFile fileAppender;

        public Appender(ILayout layout, ILogFile fileAppender)
        {
            this.fileAppender = fileAppender;
            this.layout = layout;
        }
        public void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel>=this.ReportLevel)
            {
                this.MessageCount++;
                string content = string.Format(this.layout.Format, dateTime, errorLevel, message) + Environment.NewLine;
                File.AppendAllText(path, content);
            }
        }

        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; private set; }
    }
}
