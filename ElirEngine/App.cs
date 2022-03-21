namespace ElirEngine
{
    /// <summary>
    /// Clase padre de cualquier aplicación de Elir.
    /// Tan solo puede instanciarse a través de una clase hija.
    /// </summary>
    public abstract class App
    {
        /// <summary>
        /// El método Run se llama justo después de que
        /// la aplicación sea creada y ejecuta el bucle
        /// principal de Elir.
        /// </summary>
        public void Run()
        {
            while (true) ;
        }

        /// <summary>
        /// Este método ha de llamarse en el Entry Point
        /// de cualquier solución que implemente Elir.
        /// </summary>
        /// <param name="app">Implementación de una aplicación de Elir.</param>
        public static void Create(App app)
            => app.Run();
    }
}