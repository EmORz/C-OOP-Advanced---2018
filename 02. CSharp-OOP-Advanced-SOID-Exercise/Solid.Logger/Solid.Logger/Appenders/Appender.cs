namespace Solid.Logger.Appenders
{
    using Contracts;
    using Loggers.Enum;
    using Solid.Logger.Layouts.Contracts;

    public abstract class Appender: IAppender
    {

        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }


        protected ILayout Layout => this.layout;

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);

        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }

     
    }
}
