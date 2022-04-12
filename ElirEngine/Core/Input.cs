using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ElirEngine.Core
{
    public static class Input
    {
        public static event Action<KeyArgs>? OnKeyDown;
        public static event Action<KeyArgs>? OnKeyUp;

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
