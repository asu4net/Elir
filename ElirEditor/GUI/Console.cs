using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
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
            var line = new TextBlock();
            line.Text = args.message;
            Brush textColor = Brushes.Green;
            switch (args.level)
            {
                case Log.Level.Info: textColor = Brushes.Black; break;
                case Log.Level.Warn: textColor = Brushes.Yellow; break;
                case Log.Level.Error: textColor = Brushes.Red; break;
            }
            line.Foreground = textColor;
            panel.Children.Add(line);
        }
    }
}