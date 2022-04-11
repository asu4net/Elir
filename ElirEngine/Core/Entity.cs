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

        public Transform? transform;
        public MeshRenderer? meshRenderer;

        public Entity(string name = "Entity")
        {
            this.name = name;
            AddComponent<Transform>();
        }

        List<Component> components = new List<Component>();

        public T? AddComponent<T>() where T : Component, new()
        {
            var component = new T();

            if (component == null)
                return null;

            if (component is MeshRenderer)
                meshRenderer = component as MeshRenderer;

            if (component is Transform)
                transform = component as Transform;

            components.Add(component);
            component.entity = this;
            return component;
        }

        public T? GetComponent<T>() where T : Component
        {
            var component = components.Find(c => c.GetType().Equals(typeof(T)));

            if (component == null)
                return null;

            return component as T;
        }

        public void UpdateEssentialComponents(TimeSpan delta)
        {
            if (transform != null)
                transform.Update(delta);

            if (meshRenderer != null)
                meshRenderer.Update(delta);
        }

        public void LoadComponents()
            => components.ForEach(c => c.Load());

        public void StartComponents()
            => components.ForEach(c => c.Start());

        public void UpdateComponents(TimeSpan delta)
            => components.ForEach(c => c.Update(delta));

        public void UnloadComponents()
            => components.ForEach(c => c.Unload());
    }
}
