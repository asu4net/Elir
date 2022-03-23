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

            //Creación de la implementación de ElirEngine para el editor.
            editorApp = (EditorApp) ElirEngine.App.Create(new EditorApp
                (new Renderer(Renderer.WindowSettings.Default)));

            var settings = new GLWpfControlSettings
            {
                MajorVersion = editorApp.Renderer.wSettings.glMinorVersion,
                MinorVersion = editorApp.Renderer.wSettings.glMajorVersion,
            };

            //Inicio de la ventana de WPF TK Control.
            OpenTkControl.Start(settings);          

            OpenTkControl.Loaded += (a, b) => { editorApp.Renderer.OnLoad(); };
            OpenTkControl.Render += editorApp.Renderer.OnRenderFrame;
        }
    }
}
