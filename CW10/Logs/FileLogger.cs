namespace CW10.Logs
{
    public class FileLogger : ILogger
    {
        private readonly string _path = "logs.txt";

        public FileLogger()
        {
            var dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }

        public void Info(string message)
        {
            string text = $"[LOG] {DateTime.Now} - {message}";
            File.AppendAllText(_path, text + Environment.NewLine);
        }

        public void Error(string message)
        {
            string text = $"[ERROR] {DateTime.Now} - {message}";
            File.AppendAllText(_path, text + Environment.NewLine);

        }

        /*private void Append(string level, string message, Exception? ex)
        {
            var line = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_path, line + Environment.NewLine);
            if (ex != null)
                File.AppendAllText(_path, ex + Environment.NewLine);
        }*/
    }
}