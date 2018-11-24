

namespace Solid.Logger.Appenders
{
    using Solid.Logger.Appenders.Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers.Enum;

    public abstract class Appender: IAppender
    {

        private readonly ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }


        protected ILayout Layout => this.layout;

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);

        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }

     
    }
}
