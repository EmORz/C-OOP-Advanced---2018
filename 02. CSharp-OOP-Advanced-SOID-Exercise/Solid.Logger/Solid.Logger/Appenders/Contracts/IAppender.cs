
namespace Solid.Logger.Appenders.Contracts
{
    using Loggers.Enum;

    public interface IAppender
    {
        void Append(string dateTime, ReportLevel errorLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessageCount { get; }
    }
}
