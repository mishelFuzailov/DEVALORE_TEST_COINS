using System;
using System.IO;

namespace DEVALORE_TEST_COINS.Utils
{
    public class WriteToLog
    {
        private string path;
        public WriteToLog(string path)
        {
            this.path = path;
        }


        public void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(path))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine($"{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }
    }
}
