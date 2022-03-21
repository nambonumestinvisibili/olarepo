using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lista6DawidHolewa
{
    public interface ILogger
    {
        void Log(string message);
    }

    public enum LogType { None, Console, File}

    public class LoggerFactory
    {
        public ILogger GetLogger (LogType logType, string Parameters = null)
        {
            if (logType == LogType.Console)
            {
                return new ConsoleLogger();
            }
            else if (logType == LogType.File && Parameters != null)
            {
                return new FileLogger(Parameters);
            }
            else if (logType == LogType.None)
            {
                return new NullLogger();
            }
            else
            {
                throw new Exception("No implementation for this LogType");
            }
        }


        private static LoggerFactory Instance;

        public static LoggerFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LoggerFactory();
            }
            return Instance;
        }

        class NullLogger : ILogger
        {
            public void Log(string message)
            {
                
            }
        }

        class FileLogger : ILogger
        {
            string FilePath;

            public FileLogger(string filePath)
            {
                FilePath = filePath;
            }

            public void Log(string message)
            {
                StreamWriter sw = File.CreateText(FilePath);
                sw.WriteLineAsync(message);
                sw.Close();
            }
        }

        class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
