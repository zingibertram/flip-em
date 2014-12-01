using FlipEm.Core;
using Games.Core;
using System.Windows;

namespace FlipEm
{
    public partial class FlipEmSettingsView : ISettings
    {
        private readonly FlipEmSettings _settings = new FlipEmSettings();

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
