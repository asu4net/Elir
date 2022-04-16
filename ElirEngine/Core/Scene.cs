using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Rendering;
using OpenTK.Mathematics;

namespace ElirEngine.Core
{
    public class Scene
    {
        public static Camera? MainCamera { get; private set; }

        public string name;
        public int buildIndex;

        Renderer renderer;

        List<Entity> entities = new List<Entity>();

        public Scene(string name, int buildIndex, Renderer renderer)
        {
            this.name = name;
            this.buildIndex = buildIndex;
            this.renderer = renderer;
            renderer.OnWindowLoaded += Load;
            renderer.OnUpdate += UpdateEntityEssentials;
            renderer.OnDestroy += Unload;

            CreateMainCamera();
        }

        void CreateMainCamera()
        {
            var entity = new Entity();
            var transform = entity.transform;

            if (transform != null)
                transform.Position = new Vector3(0, 0, -5f);

            MainCamera = entity.AddComponent<Camera>();
            
            AddEntity(entity);
        }

        public void AddEntity(Entity entity)
            => entities.Add(entity);

        public void Load()
            => entities.ForEach(e => e.LoadComponents());

        public void Init()
        {
            renderer.OnUpdate -= UpdateEntityEssentials;
            entities.ForEach(e => e.StartComponents());
            renderer.OnUpdate += UpdateEntities;
        }

        public void Unload()
            => entities.ForEach(e => e.UnloadComponents());

        void UpdateEntityEssentials(TimeSpan delta)
            => entities.ForEach(e => e.UpdateEssentialComponents(delta));

        void UpdateEntities(TimeSpan delta)
            => entities.ForEach(e => e.UpdateComponents(delta));
    }
}
