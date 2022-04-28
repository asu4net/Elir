namespace ElirEngine
{
    /// <summary>
    /// Clase padre de cualquier aplicación de Elir.
    /// Tan solo puede instanciarse a través de una clase hija.
    /// </summary>
    public abstract class ElirApp
    {
        /// <summary>
        /// El método Run se llama justo después de que
        /// la aplicación sea creada y por defecto crea
        /// una ventana de OpenTK.
        /// </summary>
        public virtual void Run()
        {
            ElirWindow window = new ElirWindow();
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
            return app;
        }
    }
}