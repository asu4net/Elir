﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ElirEngine
{
    public class MeshRenderer : Component
    {
        Color4 shapeColor = Color4.Red;
        
        public Mesh? mesh;
        
        Shader? shader;

        const string COLOR_ATR_NAME = "shapeColor";

        const string MODEL_ATR_NAME = "model";
        const string PROJECTION_ATR_NAME = "projection";
        const string VIEW_ATR_NAME = "view";

        Matrix4 model;

        public override void OnLoad()
        {
            shader = new Shader();
            shader.Use();
            //shader.SetUniformVec4(COLOR_ATR_NAME, (Vector4)shapeColor);
        }

        public override void Update()
        {
            if (shader == null || mesh == null)
                return;

            shader.Use();

            var activeScene = Scene.CurrentActiveScene;

            if (activeScene != null)
            {
                shader.SetUniformMat4(PROJECTION_ATR_NAME, activeScene.MainCamera.Projection);
                shader.SetUniformMat4(VIEW_ATR_NAME, activeScene.MainCamera.View);
            }

            model = Matrix4.Identity;

            model *= Matrix4.CreateRotationX(entity.transform.rotation.X);
            model *= Matrix4.CreateRotationY(entity.transform.rotation.Y);
            model *= Matrix4.CreateRotationZ(entity.transform.rotation.Z);

            model *= Matrix4.CreateTranslation(entity.transform.position);

            model *= Matrix4.CreateScale(entity.transform.scale);

            shader.SetUniformMat4(MODEL_ATR_NAME, model);

            mesh.Render();
        }
    }
}
