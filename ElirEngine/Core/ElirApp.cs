using ElirEngine.Rendering;

namespace ElirEngine.Core
{
    /// <summary>
    /// Clase padre de cualquier aplicación de Elir.
    /// Tan solo puede instanciarse a través de una clase hija.
    /// </summary>
    public abstract class ElirApp
    {
        public Renderer Renderer { get; private set; }

        protected ElirApp(Renderer renderer)
        {
            Renderer = renderer;
        }

        /// <summary>
        /// El método Run se llama justo después de que
        /// la aplicación sea creada y por defecto crea
        /// una ventana de elir.
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
        public static ElirApp Create(ElirApp app)
        {
            app.Run();
            Log.Debug("Aplicación creada.");
            return app;
        }
    }
}