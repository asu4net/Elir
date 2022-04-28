using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine
{
    public class Camera : Component
    {
        public Vector2 size = new Vector2(100, 100);
        public float fov = 45;

        public Matrix4 Projection => 

            Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov),
                size.X / size.Y, 0.1f, 100.0f);

        public Matrix4 View
        {
            get
            {
                if (entity.transform == null)
                    return default;
                return Matrix4.CreateTranslation(entity.transform.position);
            }
        }
    }
}
