
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using System;

    public class ConsoleAppender : Appenderr
    {
   

        public ConsoleAppender(ILayout layout): base(layout)
        {
     
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel>=this.ReportLevel)
            {
                this.MessageCount++;
                string temp = string.Format(this.Layout.Format, dateTime, errorLevel, message);
                Console.WriteLine(temp);
            }
         
        }
        //TODO
        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }
    }
}
