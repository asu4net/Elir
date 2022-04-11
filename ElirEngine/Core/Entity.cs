using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public class Entity
    {
        public List<Component> Components { get; private set; } = new List<Component>();

        public string name;

        public Entity(string name = "Entity")
            => this.name = name;

        public void AddComponent(Component component)
        {
            Components.Add(component);
            component.entity = this;
        }

        public T? GetComponent<T>() where T : Component
        {
            var component = Components.Find(c => c.GetType().Equals(typeof(T)));

            if (component == null)
                return null;

            return component as T;
        }
    }
}
