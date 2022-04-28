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
    public class ElirWindow : GameWindow
    {
        public ElirWindow()

            : base(GameWindowSettings.Default,

                  new NativeWindowSettings()
                  {
                      Size = new Vector2i(Renderer.wSettings.xSize, Renderer.wSettings.ySize),
                      APIVersion = new Version(Renderer.wSettings.glMinorVersion, Renderer.wSettings.glMajorVersion)
                  })
        {}

        protected override void OnLoad()
        {
            //Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
            
            KeyDown += (args) =>
            {
                Input.KeyArgs keyArgs = new Input.KeyArgs();
                keyArgs.key = args.Key;
                keyArgs.isRepeat = args.IsRepeat;
                Input.KeyDown(keyArgs);
            };

            KeyUp += (args) =>
            {
                Input.KeyArgs keyArgs = new Input.KeyArgs();
                keyArgs.key = args.Key;
                keyArgs.isRepeat = args.IsRepeat;
                Input.KeyUp(keyArgs);
            };

            Renderer.Load();
        }

        protected override void OnResize(ResizeEventArgs e)
            => GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            TimeSpan timeSpan = TimeSpan.FromSeconds(args.Time);
            Renderer.RenderFrame(timeSpan);
            SwapBuffers();
        }

        protected override void OnUnload()
            => Renderer.Unload();
    }
}
