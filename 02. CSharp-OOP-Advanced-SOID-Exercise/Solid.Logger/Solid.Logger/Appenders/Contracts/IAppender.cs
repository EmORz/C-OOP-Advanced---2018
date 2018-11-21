using Solid.Logger.Loggers.Enum;

namespace Solid.Logger.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel errorLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessageCount { get; }
    }
}
