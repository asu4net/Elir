using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using ElirEngine.Console;

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

        int VBO; //Vertex Buffer Object
        int VAO; //Vertex Array Object

        Shader? shader;

        const string POS_ATR_NAME = "aPosition";
        const string COLOR_ATR_NAME = "shapeColor";

        Color4 backgroundColor = Color4.Black;
        Color4 shapeColor = Color4.Red;

        float[] vertices =
        {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
             0.5f, -0.5f, 0.0f, //Bottom-right vertex
             0.0f,  0.5f, 0.0f  //Top vertex
        };

        //Llamar cuando se cargue la ventana.
        public void OnLoad()
        {
            Log.Debug("Renderer iniciado.");
            
            VBO = GL.GenBuffer();
            VAO = GL.GenVertexArray();
            
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices,
                BufferUsageHint.StaticDraw);

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

            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            GL.DeleteBuffer(VBO);
            GL.DeleteBuffer(VAO);

            if (shader == null)
                return;
            shader.Dispose();
        }
    }
}
