using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Core;
using ElirEngine.Rendering;

namespace Game
{
    public class GameApp : ElirApp
    {
        Scene defaultScene;

        public GameApp(Renderer renderer) : base(renderer)
        {
            defaultScene = new Scene("Default", 0, renderer);        
        }

        public override void Run()
        {
            var pyramid = new Entity("Pyramid");
            pyramid.AddComponent<MeshRenderer>();
            defaultScene.AddEntity(pyramid);
            defaultScene.Activate();

            base.Run();
        }
    }
}
