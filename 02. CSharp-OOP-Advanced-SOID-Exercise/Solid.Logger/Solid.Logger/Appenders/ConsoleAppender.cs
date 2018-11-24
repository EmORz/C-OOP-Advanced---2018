


using System;

namespace Solid.Logger.Appenders
{
    using Layouts.Contracts;
    using Loggers.Enum;

    public class ConsoleAppender : Appender
    {

        //public ReportLevel ReportLevel { get; set; }
        //public int MessageCount { get; private set; }

        public ConsoleAppender(ILayout layout): base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel>=this.ReportLevel)
            {
                string temp = string.Format(this.Layout.Format, dateTime, errorLevel, message);
                this.MessageCount++;

                Console.WriteLine(temp);
            }
         
        }
     
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}";
        }
    }
}
