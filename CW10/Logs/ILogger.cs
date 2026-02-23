namespace CW10.Logs
{
    internal interface ILogger
    {
        void Info(string message);
        void Error(string message);
        // void Error(string message, Exception? ex = null);
    }
}