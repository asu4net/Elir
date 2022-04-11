using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ElirEngine.Rendering
{
    /// <summary>
    /// En esta clase contendrá métodos relacionados
    /// con el renderizado del engine en los que se
    /// ejecutará código de OpenGL.
    /// </summary>
    public class Renderer
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

        public WindowSettings wSettings { get; private set; }

        public Renderer(WindowSettings wSettings) 
            => this.wSettings = wSettings;

        public event Action? OnWindowLoaded;
        public event Action<TimeSpan>? OnUpdate;
        public event Action? OnDestroy;

        Color4 backgroundColor = Color4.Black;

        //Llamar cuando se cargue la ventana.
        public void OnLoad()
        {
            Log.Debug("Renderer iniciado.");
            OnWindowLoaded?.Invoke();
        }

        //Llamar cada vez que se renderiza un frame.
        public void OnRenderFrame(TimeSpan delta)
        {
            GL.ClearColor(backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            OnUpdate?.Invoke(delta);

            GL.Finish();
        }

        public void OnUnload()
            => OnDestroy?.Invoke();
    }
}
