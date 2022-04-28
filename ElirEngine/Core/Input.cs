using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static event Action<KeyArgs>? OnKeyDown;
        public static event Action<KeyArgs>? OnKeyUp;

        /// <summary>
        /// Información mínima para un evento de teclado.
        /// </summary>
        public struct KeyArgs
        {
            public Keys key;
            public bool isRepeat;
        }
        
        public static void KeyDown(KeyArgs args)
            => OnKeyDown?.Invoke(args);

        public static void KeyUp(KeyArgs args)
            => OnKeyUp?.Invoke(args);
    }
}
