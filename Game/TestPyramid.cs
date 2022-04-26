using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Core;
using ElirEngine.Rendering;
using OpenTK.Mathematics;

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

        public override void Load()
        {
            var mesh = new Mesh(vertices, indices, 12, 12);
            var meshRenderer = entity.GetComponent<MeshRenderer>();
            
            if (meshRenderer == null) return;
            
            meshRenderer.mesh = mesh;
        }

        public override void Update(TimeSpan delta)
        {
            var t = entity.transform;
            t.rotation = new Vector3(0, t.rotation.Y + delta.Milliseconds * 0.001f, 0);
        }
    }
}
