using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristiAndersen.EasyLog
{
    public static class Log
    {
        private static LogBase logger = null;
        private static string datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        private static void WriteLine(string text)
        {
            logger = new FileLogger();
            logger.Write(System.DateTime.Now.ToString(datetimeFormat) + text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public static void Error(string text)
        {
            WriteFormattedLog(LogLevel.Error, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public static void Information(string text)
        {
            WriteFormattedLog(LogLevel.Information, text);
        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public static void Debug(string text)
        {
            WriteFormattedLog(LogLevel.Debug, text);
        }

        private static void WriteFormattedLog(LogLevel level, string text)
        {
            string typeText = "";
            switch (level)
            {
                case LogLevel.Debug:
                    typeText = " [Debug] ";
                    break;
                case LogLevel.Information:
                    typeText = " [Information] ";
                    break;
                case LogLevel.Error:
                    typeText = " [Error] ";
                    break;
            }

            WriteLine(typeText + text);
        }

        [System.Flags]
        private enum LogLevel
        {
            Debug,
            Information,
            Error
        }
    }
}
