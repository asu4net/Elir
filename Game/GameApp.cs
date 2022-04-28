using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using ElirEngine;

namespace Game
{
    public class GameApp : ElirApp
    {
        Scene defaultScene;

        public GameApp()
        {
            defaultScene = new Scene("Default", 0);        
        }

        public override void Run()
        {
            var pyramid1 = CreatePyramid();
            var pyramid2 = CreatePyramid();

            pyramid2.transform.position = new Vector3(2, 0, 0);
            
            defaultScene.Activate();
            base.Run();
        }

        Entity CreatePyramid()
        {
            Entity pyramid = new Entity("Pyramid");

            pyramid.AddComponent<MeshRenderer>();
            pyramid.AddComponent<TestPyramid>();

            defaultScene.AddEntity(pyramid);

            return pyramid;
        }
    }
}
