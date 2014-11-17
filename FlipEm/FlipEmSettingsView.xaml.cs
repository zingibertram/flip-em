using FlipEm.Core;
using Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlipEm
{
    /// <summary>
    /// Логика взаимодействия для FlipEmSettingsView.xaml
    /// </summary>
    public partial class FlipEmSettingsView : ISettings
    {
        private FlipEmSettings _settings = new FlipEmSettings();

        public FlipEmSettingsView()
        {
            InitializeComponent();
        }

        public object Settings
        {
            get { return _settings; }
        }

        public FrameworkElement View
        {
            get { return this; }
        }
    }
}
