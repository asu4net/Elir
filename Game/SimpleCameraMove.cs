using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Game
{
    internal class SimpleCameraMove : Component
    {
        float speed = 5;

        public override void Update()
        {
            var rotDir = new Vector3(Input.Mouse.X, Input.Mouse.Y, 0);
            entity.transform.rotation += rotDir * speed * Time.deltaTime;
            Console.WriteLine(entity.transform.rotation);

            var dir = new Vector3(Input.Axis3D.X, 0, Input.Axis3D.Y);
            entity.transform.position += dir * speed * Time.deltaTime;
        }
    }
}
