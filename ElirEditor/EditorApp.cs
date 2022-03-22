using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElirEngine;

namespace ElirEditor
{
    /// <summary>
    /// Clase principal del Elir Editor. Se crea justo
    /// después de iniciar la ventana de WPF. Aquí irá
    /// la lógica relacionada con el editor.
    /// </summary>
    public class EditorApp : ElirEngine.App
    {
        /* Sobreescribimos Run borrando el base para 
         * evitar la creación de una ventana de Elir Engine,
         * ya que la librería de WPF TK COntrol provee la suya 
         * específica. */
        public override void Run() {}
    }
}
