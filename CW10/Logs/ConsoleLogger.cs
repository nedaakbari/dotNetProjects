namespace CW10.Logs
{
    namespace CW10.Logging
    {
        public class ConsoleLogger : ILogger
        {
            public void Info(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // Console.WriteLine($"[INFO] {DateTime.Now} - {message}");
                Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            }

            public void Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            }

            // public void Error(string message, Exception? ex = null)
            // {
            //     Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            //     if (ex != null) Console.WriteLine(ex);
            // }
        }
    }
}