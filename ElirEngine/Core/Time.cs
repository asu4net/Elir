using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine
{
    /// <summary>
    /// Clase estática que se encarga de calcular 
    /// el  deltaTime.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// Tiempo que ha pasado desde el último
        /// frame en segundos.
        /// </summary>
        public static float deltaTime { get; private set; }

        static float lastTime;

        /// <summary>
        /// Función que se llama desde el Renderer y setea
        /// la variable deltaTime.
        /// </summary>
        /// <param name="currentTime">Tiempo que pasó desde que se inició el Renderer</param>
        internal static void CalculateDeltaTime(float currentTime)
        {
            deltaTime = currentTime - lastTime;
            lastTime = currentTime;
        }
    }
}
