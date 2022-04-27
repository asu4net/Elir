using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public class Entity
    {
        public string name;
        public Transform transform;

        public Entity(string name = "Entity")
        {
            this.name = name;
            transform = AddComponent<Transform>();
        }

        List<Component> components = new List<Component>();

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();

            components.Add(component);
            component.entity = this;
            return component;
        }

        public T? GetComponent<T>() where T : Component
        {
            var component = components.Find(c => c.GetType().Equals(typeof(T)));

            if (component is null)
                return null;

            return component as T;
        }

        public void LoadComponents()
            => components.ForEach(c => c.OnLoad());
        public void UpdateComponents()
            => components.ForEach(c => c.Update());
        public void UnloadComponents()
            => components.ForEach(c => c.OnUnload());
    }
}
