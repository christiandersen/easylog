using System.IO;

namespace ChristiAndersen.EasyLog
{
    public class FileLogger : LogBase
    {
        private const string fileExtension = ".log";
        private const string dropPath = @"c:\temp";

        private readonly bool append = true;

        private string LogFilePath { get; } = Path.Combine(dropPath, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name) + fileExtension;

        public override void Write(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            lock (lockObject)
            {
                using (StreamWriter streamWriter = new StreamWriter(LogFilePath,append, System.Text.Encoding.UTF8))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}
