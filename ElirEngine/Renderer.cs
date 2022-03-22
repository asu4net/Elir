using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ElirEngine
{
    /// <summary>
    /// En esta clase contendrá métodos relacionados
    /// con el renderizado del engine en los que se
    /// ejecutará código de OpenGL.
    /// </summary>
    public class Renderer
    {
        public void Render()
        {
            GL.ClearColor(new Color4(0, 32, 48, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        }
    }
}
