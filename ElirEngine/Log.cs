using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ElirEngine
{
    /// <summary>
    /// Clase que gestiona los Logs del Engine.
    /// Implementa log4net.
    /// </summary>
    public static class Log
    {
        public struct ReleasedArgs
        {
            public Level level;
            public string message;

            public ReleasedArgs(Level level, string message)
            {
                this.level = level;
                this.message = message;
            }
        }
        public enum Level { Debug, Info, Warn, Error }


        public static event Action<ReleasedArgs>? OnReleased;

        public static string LastLog
        {
            get
            {
                var fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var lines = new List<string>();
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }
                return lines[lines.Count-1];
            }
        }
        public static string FilePath => 
            $"{AppDomain.CurrentDomain.BaseDirectory}{LOG_FILE_NAME}";
        public static Level CurrentLevel
        {
            get => currentLevel;

            set
            {
                currentLevel = value;

                switch (currentLevel)
                {
                    case Level.Debug: log4netLevel = log4net.Core.Level.Debug; return;
                    case Level.Info: log4netLevel = log4net.Core.Level.Info; return;
                    case Level.Warn: log4netLevel = log4net.Core.Level.Warn; return;
                    case Level.Error: log4netLevel = log4net.Core.Level.Error; return;
                }
            }
        }

        public const string LOG_FILE_NAME = "Logs.txt";

        static Level currentLevel = Level.Debug;
        static log4net.Core.Level log4netLevel = log4net.Core.Level.Debug;

        public static bool IsConfigured => LogManager.GetRepository().Configured;

        public static void Debug(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Debug(message);
            InvokeOnReleased(Level.Debug);
        }

        public static void Info(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Info(message);
            InvokeOnReleased(Level.Info);
        }

        public static void Warn(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Warn(message);
            InvokeOnReleased(Level.Warn);
        }

        public static void Error(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Error(message);
            InvokeOnReleased(Level.Error);
        }

        static void InvokeOnReleased(Level level)
            => OnReleased?.Invoke(new ReleasedArgs(level, LastLog));

        static ILog ConfigILog(string sender)
        {
            GlobalContext.Properties["Sender"] = GetFileNamespace(sender);
            ILog log = LogManager.GetLogger(GetFileName(sender));
            ((log4net.Repository.Hierarchy.Logger)log.Logger).Level = log4netLevel;
            return log;
        }

        static string GetFileName(string sender)
        {
            var fileNameArray = sender.Split('\\');
            return fileNameArray[fileNameArray.Length - 1].Replace(".cs", "");
        }

        static string GetFileNamespace(string sender)
        {
            var fileNameArray = sender.Split('\\');
            return fileNameArray[fileNameArray.Length - 2];
        }
    }

    public class SpecialFolderPatternConverter : log4net.Util.PatternConverter
    {
        override protected void Convert(TextWriter writer, object state)
        {
            writer.Write($"{AppDomain.CurrentDomain.BaseDirectory}" +
                $"{@"\"}{Log.LOG_FILE_NAME}");
        }
    }
}