using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine
{
    public class Mesh : IDisposable
    {
        int VAO;
        int VBO;
        int IBO;

        int indexCount;

        public Mesh(float[] vertices, int[] indices, int numOfVertices, int numOfIndices)
        {
            indexCount = numOfIndices;

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            GL.GenBuffers(1, out IBO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(int) * numOfIndices, indices, BufferUsageHint.StaticDraw);

            GL.GenBuffers(1, out VBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);

            /* Facilitamos los tipos de datos y nuestro array de vertices. */
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * numOfVertices, vertices, BufferUsageHint.StaticDraw);
            //Le decimos a OpenGL cómo ha de organizar la info del buffer que le pasamos.
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            //Activamos el índice 0 del vertex (el atributo posición)
            GL.EnableVertexAttribArray(0);

            //Liberamos los buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        ~Mesh()
            => Clear();

        public void Dispose()
            => Clear();

        public void Render()
        {
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
            GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }

        public void Clear()
        {
            if (IBO != 0)
                GL.DeleteBuffer(IBO);

            if (VBO != 0)
                GL.DeleteBuffer(VBO);

            if (VAO != 0)
                GL.DeleteVertexArray(VAO);
        }
    }
}
