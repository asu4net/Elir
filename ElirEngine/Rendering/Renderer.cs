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

        public event Action<TimeSpan>? OnUpdate;

        //int VBO; //Vertex Buffer Object
        //int VAO; //Vertex Array Object

        Shader? shader;

        const string POS_ATR_NAME = "aPosition";
        const string COLOR_ATR_NAME = "shapeColor";

        Color4 backgroundColor = Color4.Black;
        Color4 shapeColor = Color4.Red;

        int[] indices = {
            0, 3, 1,
            1, 3, 2,
            2, 3, 0,
            0, 1, 2
        };

        float[] vertices = {
            -1.0f, -1.0f, 0.0f,
             0.0f, -1.0f, 1.0f,
             1.0f, -1.0f, 0.0f,
             0.0f,  1.0f, 0.0f
        };

        Mesh triangle;

        //Llamar cuando se cargue la ventana.
        public void OnLoad()
        {
            Log.Debug("Renderer iniciado.");
            
            triangle = new Mesh(vertices, indices, 12, 12);

            shader = new Shader();

            var posAtrPtr = shader.GetAttribLocation(POS_ATR_NAME);

            GL.VertexAttribPointer(posAtrPtr, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(posAtrPtr);

            shader.Use();
            shader.SetUniformVec4(COLOR_ATR_NAME, (Vector4)shapeColor);
        }

        //Llamar cada vez que se renderiza un frame.
        public void OnRenderFrame(TimeSpan delta)
        {
            GL.ClearColor(backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            if (shader != null)
                shader.Use();

            if (triangle != null)
                triangle.Render();

            GL.Finish();
        }

        public void OnUnload()
        {
            triangle.Dispose();

            if (shader == null)
                return;
            shader.Dispose();
        }
    }
}
