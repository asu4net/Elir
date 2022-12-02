using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine;
using OpenTK.Mathematics;

namespace Game
{
    internal class MoveEntity : Component
    {
        public override void Update()
        {
            var dir = new Vector3(Input.Axis3D.X, 0, Input.Axis3D.Y);
            entity.transform.position += dir * 5 * Time.deltaTime;  
        }
    }
}
