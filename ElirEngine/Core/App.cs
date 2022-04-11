using ElirEngine.Rendering;

namespace ElirEngine.Core
{
    /// <summary>
    /// Clase padre de cualquier aplicación de Elir.
    /// Tan solo puede instanciarse a través de una clase hija.
    /// </summary>
    public abstract class App
    {
        public Renderer Renderer { get; private set; }
        Scene scene;

        protected App(Renderer renderer)
        {
            Renderer = renderer;
            
            
            scene = new Scene("Default", 0, Renderer);

            var pyramid = new Entity();
            pyramid.AddComponent<MeshRenderer>();
            scene.AddEntity(pyramid);
        
        }

        /// <summary>
        /// El método Run se llama justo después de que
        /// la aplicación sea creada y ejecuta el bucle
        /// principal de Elir.
        /// </summary>
        public virtual void Run()
        {
            Window window = new Window(Renderer);
            window.Run();
        }

        /// <summary>
        /// Este método ha de llamarse en el Entry Point
        /// de cualquier solución que implemente Elir.
        /// </summary>
        /// <param name="app">Implementación de una aplicación de Elir.</param>
        public static App Create(App app)
        {
            app.Run();
            Log.Debug("Aplicación creada.");
            return app;
        }
    }
}