using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Rendering;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ElirEngine.Core
{
    public class MeshRenderer : Component
    {
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

        Color4 shapeColor = Color4.Red;

        Mesh? mesh;
        Shader? shader;

        const string POS_ATR_NAME = "aPosition";
        const string COLOR_ATR_NAME = "shapeColor";

        const string MODEL_ATR_NAME = "model";
        const string PROJECTION_ATR_NAME = "projection";
        const string VIEW_ATR_NAME = "view";

        Matrix4 model;

        public override void Load()
        {
            mesh = new Mesh(vertices, indices, 12, 12);

            shader = new Shader();

            var posAtrPtr = shader.GetAttribLocation(POS_ATR_NAME);

            GL.VertexAttribPointer(posAtrPtr, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(posAtrPtr);

            shader.Use();
            shader.SetUniformVec4(COLOR_ATR_NAME, (Vector4)shapeColor);
        }

        public override void Update(TimeSpan delta)
        {
            Locate();
        }

        void Locate()
        {
            if (entity.transform == null || shader == null || mesh == null)
                return;

            shader.Use();

            var camera = Scene.MainCamera;

            if (camera != null)
            {
                shader.SetUniformMat4(PROJECTION_ATR_NAME, camera.Projection);
                shader.SetUniformMat4(VIEW_ATR_NAME, camera.View);
            }

            model = Matrix4.Identity;
            model *= Matrix4.CreateTranslation(entity.transform.Position);
            model *= Matrix4.CreateScale(entity.transform.Scale);

            shader.SetUniformMat4(MODEL_ATR_NAME, model);

            mesh.Render();
        }
    }
}
