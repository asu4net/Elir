using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK.Wpf;
using ElirEngine;

using Window = System.Windows.Window;

namespace ElirEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EditorApp editorApp;

        public MainWindow()
        {
            InitializeComponent();

            //Inicio de la ventana de WPF TK Control.
            #region WPF TK Control
            var settings = new GLWpfControlSettings
            {
                MajorVersion = 4,
                MinorVersion = 5,
            };

            OpenTkControl.Start(settings);
            #endregion

            Log.Info("Ventana de Open TK Control creada.");

            //Creación de la implementación de ElirEngine para el editor.
            editorApp = (EditorApp) ElirEngine.App.Create(new EditorApp());
        }

        //Método que llama WPF TK Control cuando renderiza un frame.
        private void OpenTkControl_OnRender(TimeSpan delta)
        {
            //En ausencia de una ventana del motor llamamos al Renderer
            editorApp.Renderer.Render();
        }
    }
}
