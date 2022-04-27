using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public static class Time
    {
        /// <summary>
        /// Tiempo que ha pasado desde el último
        /// frame en segundos.
        /// </summary>
        public static float deltaTime { get; private set; }

        static float lastTime;

        //TODO: cambiar por internal al reorganizar los packages
        public static void CalculateDeltaTime(float currentTime)
        {
            deltaTime = currentTime - lastTime;
            lastTime = currentTime;
        }
    }
}
