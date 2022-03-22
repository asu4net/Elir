using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ElirEngine
{
    /// <summary>
    /// Controla la ventana principal de Elir.
    /// Ejecuta funciones de OpenGL en un Framework 
    /// simplificado por las librerías de OpenTK.
    /// </summary>
    public class Window : GameWindow
    {
        Renderer renderer;

        public Window(Renderer renderer)

            : base(GameWindowSettings.Default,

                  new NativeWindowSettings()
                  {
                      Size = new Vector2i(1600, 900),
                      APIVersion = new Version(4, 5)
                  })
        {
            this.renderer = renderer;
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            
            //Actualizamos el viewport de OpenGL
            GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            renderer.Render();
            SwapBuffers();
        }
    }
}
