using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Appenders
{
    public abstract class Appenderr: IAppender

    {

        private readonly ILayout layout;

        public Appenderr(ILayout layout)
        {
            this.layout = layout;
        }


        protected ILayout Layout => this.layout;

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);

        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}";
        }
    }
}
