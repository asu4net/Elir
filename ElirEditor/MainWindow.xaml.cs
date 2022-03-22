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

            var settings = new GLWpfControlSettings
            {
                MajorVersion = 4,
                MinorVersion = 5,
            };

            OpenTkControl.Start(settings);

            editorApp = (EditorApp) ElirEngine.App.Create(new EditorApp());
        }

        private void OpenTkControl_OnRender(TimeSpan delta)
        {
            editorApp.Renderer.Render();
        }
    }
}
