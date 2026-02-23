//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CW10.Logs
//{
//    using global::CW10.Logs.Interfaces;
//    using System;

//    namespace CW10.Logging
//    {
//        internal class ConsoleLogger : ILogger
//        {
//            public void Info(string message)
//            {
//                Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
//            }

//            public void Error(string message, Exception? ex = null)
//            {
//                Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
//                if (ex != null) Console.WriteLine(ex);
//            }
//        }
//    }

//}
