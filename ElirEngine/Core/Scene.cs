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
        public static Scene? CurrentActiveScene { get; private set; }

        public Camera MainCamera
        {
            get => mainCamera;
            
            set
            {
                if (value == null)
                    return;
                mainCamera = value;
            }
        }

        public string name;
        public int buildIndex;

        Camera mainCamera;
        List<Entity> entities = new List<Entity>();
        Vector3 startMainCamPos = new Vector3(0, 0, -5f);

        public Scene(string name, int buildIndex)
        {
            this.name = name;
            this.buildIndex = buildIndex;
            
            //Creación de la cámara por defecto.
            var mainCameraEnt = new Entity();
            mainCameraEnt.transform.position = startMainCamPos;
            mainCamera = mainCameraEnt.AddComponent<Camera>();
            AddEntity(mainCameraEnt);
        }

        public void AddEntity(Entity entity)
            => entities.Add(entity);

        public void LoadEntities()
            => entities.ForEach(e => e.LoadComponents());

        public void Activate()
        {
            if (CurrentActiveScene != null)
                Deactivate();

            Renderer.OnLoad += LoadEntities;
            Renderer.OnUnload += UnloadEntities;

            CurrentActiveScene = this;
            Renderer.OnRenderFrame += (delta) =>  UpdateEntities();
        }

        public void Deactivate()
        {
            Renderer.OnRenderFrame -= (delta) => UpdateEntities();
            Renderer.OnLoad -= LoadEntities;
            Renderer.OnUnload -= UnloadEntities;

            UnloadEntities();
        }

        public void UnloadEntities()
            => entities.ForEach(e => e.UnloadComponents());

        void UpdateEntities()
            => entities.ForEach(e => e.UpdateComponents());
    }
}