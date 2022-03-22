using log4net;
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
    /// Clase que gestiona los Log del Engine.
    /// Implementa log4net.
    /// </summary>
    public static class Log
    {
        internal static bool IsConfigured => LogManager.GetRepository().Configured;

        public static void Debug(string message)
            => ConfigILog().Debug(message);

        public static void Info(string message)
            => ConfigILog().Info(message);

        public static void Warn(string message)
            => ConfigILog().Warn(message);

        public static void Error(string message)
            => ConfigILog().Error(message);

        static ILog ConfigILog([CallerFilePath] string filePath = "")
        {
            GlobalContext.Properties["Sender"] = GetFileNamespace(filePath);
            return LogManager.GetLogger(GetFileName(filePath));
        }

        static string GetFileName(string filePath)
        {
            var fileNameArray = filePath.Split('\\');
            return fileNameArray[fileNameArray.Length - 1].Replace(".cs", "");
        }

        static string GetFileNamespace(string filePath)
        {
            var fileNameArray = filePath.Split('\\');
            return fileNameArray[fileNameArray.Length - 2];
        }
    }
}
