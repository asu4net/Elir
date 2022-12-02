using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ElirEngine
{
    /// <summary>
    /// Esta clase estática provee de eventos de Input. Sus funciones han de
    /// ser llamadas desde un contexto de ventana para funcionar.
    /// Por defecto se llaman desde ElirWindow.
    /// </summary>
    public static class Input
    {
        public static Vector2 Axis3D => axis3D;
        public static Vector2 Mouse => mouse;

        public static event Action<KeyArgs>? OnKeyDown;
        public static event Action<KeyArgs>? OnKeyUp;

        static Vector2 axis3D;
        static Vector2 mouse;

        /// <summary>
        /// Información mínima para un evento de teclado.
        /// </summary>
        public struct KeyArgs
        {
            public Keys key;
            public bool isRepeat;
        }
        
        public static void KeyDown(KeyArgs args)
        {
            if (args.key.Equals(Keys.W))
                axis3D.Y = 1;
            if (args.key.Equals(Keys.S))
                axis3D.Y = -1;
            if (args.key.Equals(Keys.A))
                axis3D.X = 1;
            if (args.key.Equals(Keys.D))
                axis3D.X = -1;

            OnKeyDown?.Invoke(args);
        }

        public static void ReadMouse(Vector2 mouseInput)
        {
            mouse.X = mouseInput.X;
            mouse.Y = mouseInput.Y;
        }

        public static void KeyUp(KeyArgs args)
        {
            if (args.key.Equals(Keys.W))
                axis3D.Y = 0;
            if (args.key.Equals(Keys.S))
                axis3D.Y = 0;
            if (args.key.Equals(Keys.A))
                axis3D.X = 0;
            if (args.key.Equals(Keys.D))
                axis3D.X = 0;

            OnKeyUp?.Invoke(args);
        }
    }
}
