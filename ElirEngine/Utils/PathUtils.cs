using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Console;

namespace ElirEngine.Utils
{
    public static class PathUtils
    {
        public static string? GetProjectDir([CallerFilePath] string sender = "")
        {
            var projectName = Assembly.GetCallingAssembly().GetName().Name;

            if (string.IsNullOrEmpty(projectName))
            {
                Log.Error($"GetProjectDir: Error en Assembly.GetCallingAssembly().");
                return default;
            }

            var senderStrList = sender.Split('\\').ToList();
            var elirEngineStr = senderStrList.Find(o => o.Contains(projectName));

            if (string.IsNullOrEmpty(elirEngineStr))
            {
                Log.Error($"GetProjectDir: Error en [CallerFilePath] {projectName}");
                return default;
            }

            int lastValidIndex = senderStrList.IndexOf(elirEngineStr);
            
            int count = 0;

            for (int i = lastValidIndex + 1; i < senderStrList.Count; i++)
                count++;
            
            senderStrList.RemoveRange(lastValidIndex + 1, count);
            
            var sb = new StringBuilder();

            for (int i = 0; i < senderStrList.Count; i++)
            {
                var slash = i == 0 ? string.Empty : @"\";
                sb.Append($"{slash}{senderStrList[i]}");
            }
            
            return sb.ToString();
        }
    }
}
