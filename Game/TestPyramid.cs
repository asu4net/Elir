using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using ElirEngine;

namespace Game
{
    internal class TestPyramid : Component
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

        float speed = 1;

        public override void OnLoad()
        {
            entity.transform.scale *= 0.5f;
            var mesh = new Mesh(vertices, indices, 12, 12);
            var meshRenderer = entity.GetComponent<MeshRenderer>();
            
            if (meshRenderer == null) return;
            
            meshRenderer.mesh = mesh;
        }

        public override void Update()
        {
            //var t = entity.transform;
            //t.rotation = new Vector3(0, t.rotation.Y + speed * Time.deltaTime, 0);
            //var rotDir = new Vector3(Input.Mouse.Y, Input.Mouse.X, 0);
            //entity.transform.rotation += rotDir * speed * Time.deltaTime;
            //Console.WriteLine(entity.transform.rotation);
        }
    }
}
