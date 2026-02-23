//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CW10.Logs
//{
//    using global::CW10.Logs.Interfaces;
//    using System;
//    using System.IO;

//    namespace CW10.Logging
//    {
//        internal class FileLogger : ILogger
//        {
//            private readonly string _path;

//            public FileLogger()
//            {
//                _path = "app.log";
//            }

//            public void Info(string message) => Append("INFO", message, null);

//            public void Error(string message, Exception? ex = null) => Append("ERROR", message, ex);

//            private void Append(string level, string message, Exception? ex)
//            {
//                var line = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
//                File.AppendAllText(_path, line + Environment.NewLine);
//                if (ex != null)
//                    File.AppendAllText(_path, ex + Environment.NewLine);
//            }
//        }
//    }

//}
