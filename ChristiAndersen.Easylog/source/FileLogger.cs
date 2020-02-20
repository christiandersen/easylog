using System.IO;
using System.Threading;

namespace EasyLog
{
    public class FileLogger : LogBase
    {
        private const string fileExtension = ".log";
        private const string dropPath = @"c:\temp";

        private readonly bool append = true;

        private static ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        
        private string GetLogFilePath()
        {
            return Path.Combine(dropPath, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name) + fileExtension;
        }

        public override void Write(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            readWriteLock.EnterWriteLock();
            try
            {
                    using (StreamWriter streamWriter = new StreamWriter(GetLogFilePath(), append, System.Text.Encoding.UTF8))
                    {
                        streamWriter.WriteLine(message);
                        streamWriter.Close();
                    }
            }
            finally 
            {
                readWriteLock.ExitWriteLock();
            }
        }
    }
}
