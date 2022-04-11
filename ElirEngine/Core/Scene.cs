using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine.Rendering;

namespace ElirEngine.Core
{
    public class Scene
    {
        public string name;
        public string buildIndex;

        bool loaded;

        List<Entity> entities = new List<Entity>();

        public Scene(string name, string buildIndex)
        {
            this.name = name;
            this.buildIndex = buildIndex;
        }

        public void AddEntity(Entity entity)
            => entities.Add(entity);

        public void Init(Renderer renderer)
        {
            renderer.OnUpdate += OnUpdate;
        }

        public void Load()
        {
            entities.ForEach(e => e.Components.ForEach(c => c.Start()));
            loaded = true;
        }

        public void Unload()
        {
            loaded = false;
        }

        void OnUpdate(TimeSpan delta)
        {
            //aquí se ejecuta el componente transform si lo hay
            //aquí se ejecuta el componente renderer si lo hay

            if (!loaded)
                return;

            entities.ForEach(e => e.Components.ForEach(c => c.Update(delta)));
        }
    }
}
