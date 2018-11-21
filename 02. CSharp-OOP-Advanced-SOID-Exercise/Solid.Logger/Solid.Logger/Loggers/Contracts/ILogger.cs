namespace Solid.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string format, string errorMessage);
        void Info(string format, string infoMessage);
     
    }
}
