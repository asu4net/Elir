using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Core;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ElirEngine.Rendering
{
    /// <summary>
    /// En esta clase contendrá métodos relacionados
    /// con el renderizado del engine en los que se
    /// ejecutará código de OpenGL.
    /// </summary>
    public static class Renderer
    {
        public struct WindowSettings
        {
            public static WindowSettings Default => new WindowSettings(1920, 1080, 4, 5);

            public int xSize;
            public int ySize;
            public int glMinorVersion;
            public int glMajorVersion;

            public WindowSettings(int xSize, int ySize, int glMinorVersion, int glMajorVersion)
            {
                this.xSize = xSize;
                this.ySize = ySize;
                this.glMinorVersion = glMinorVersion;
                this.glMajorVersion = glMajorVersion;
            }
        }

        public static WindowSettings wSettings = WindowSettings.Default;

        public static event Action? OnLoad;
        public static event Action<TimeSpan>? OnRenderFrame;
        public static event Action? OnUnload;

        public static Color4 backgroundColor = Color4.Black;

        static Stopwatch stopWatch;

        //Llamar cuando se cargue la ventana.
        public static void Load()
        {
            stopWatch = Stopwatch.StartNew();
            Log.Debug("Renderer iniciado.");
            OnLoad?.Invoke();
        }

        //Llamar cada vez que se renderiza un frame.
        public static void RenderFrame(TimeSpan delta)
        {
            GL.ClearColor(backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            Time.CalculateDeltaTime((float) stopWatch.Elapsed.TotalSeconds);
            OnRenderFrame?.Invoke(delta);

            GL.Finish();
        }

        public static void Unload()
            => OnUnload?.Invoke();
    }
}
