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
            //defaultScene.MainCamera.entity.AddComponent<SimpleCameraMove>();

            Entity pyramid = new Entity();

            pyramid.AddComponent<MoveEntity>();
            pyramid.AddComponent<MeshRenderer>();
            pyramid.AddComponent<TestPyramid>();

            defaultScene.AddEntity(pyramid);
            
            defaultScene.Activate();
            base.Run();
        }

    }
}
