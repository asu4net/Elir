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
        public static event Action<Level>? OnReleased;

        public const string LOG_FILE_NAME = "Logs.txt";
        public enum Level { Debug, Info, Warn, Error }

        public static Level CurrentLevel 
        {
            get => currentLevel;

            set
            {
                currentLevel = value;

                switch(currentLevel)
                {
                    case Level.Debug: log4netLevel = log4net.Core.Level.Debug; return;
                    case Level.Info: log4netLevel = log4net.Core.Level.Info; return;
                    case Level.Warn: log4netLevel = log4net.Core.Level.Warn; return;
                    case Level.Error: log4netLevel = log4net.Core.Level.Error; return;
                }
            }
        }
        static Level currentLevel = Level.Debug;
        static log4net.Core.Level log4netLevel = log4net.Core.Level.Debug;

        internal static bool IsConfigured => LogManager.GetRepository().Configured;

        public static void Debug(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Debug(message);
            OnReleased?.Invoke(Level.Debug);
        }

        public static void Info(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Info(message);
            OnReleased?.Invoke(Level.Info);
        }

        public static void Warn(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Warn(message);
            OnReleased?.Invoke(Level.Warn);
        }

        public static void Error(string message, [CallerFilePath] string sender = "")
        {
            ConfigILog(sender).Error(message);
            OnReleased?.Invoke(Level.Error);
        }

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