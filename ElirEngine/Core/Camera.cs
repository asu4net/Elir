using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public class Camera : Component
    {
        public Vector2 Size { get; set; } = new Vector2(100, 100);
        public float Fov { get; set; } = 45;

        public Matrix4 Projection => 

            Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov),
                Size.X / Size.Y, 0.1f, 100.0f);

        public Matrix4 View
        {
            get
            {
                if (entity.transform == null)
                    return default;
                return Matrix4.CreateTranslation(entity.transform.Position);
            }
        }
    }
}
