using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ElirEngine;

namespace ElirEditor.GUI
{
    internal class Console
    {
        StackPanel panel;

        const string PANEL_NAME = "ConsoleStackPanel";

        public Console(MainWindow mainWindow)
        {
            panel = (StackPanel) mainWindow.FindName(PANEL_NAME);
            Log.OnReleased += Log_OnReleased;
        }

        void Log_OnReleased(Log.ReleasedArgs args)
        {
            TextBlock line = new TextBlock();
            line.Text = args.message;
            panel.Children.Add(line);
        }
    }
}
