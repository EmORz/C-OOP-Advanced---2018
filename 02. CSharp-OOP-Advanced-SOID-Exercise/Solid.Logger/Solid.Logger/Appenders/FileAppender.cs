

using System;
using Solid.Logger.Loggers.Contracts;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Appenders
{
    using Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";

        private readonly ILogFile fileAppender;

        //public ReportLevel ReportLevel { get; set; }
        //public int MessageCount { get; protected set; }

        public FileAppender(ILayout layout, ILogFile fileAppender): base(layout)
        {
            this.fileAppender = fileAppender;
  
        }
        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel>=this.ReportLevel)
            {
                this.MessageCount++;
                string content = string.Format(this.Layout.Format, dateTime, errorLevel, message) + Environment.NewLine;
                this.fileAppender.Write(content);
                File.AppendAllText(path, content);
            }
        }

      

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}, File size: {this.fileAppender.Size}";
        }
    }
}
