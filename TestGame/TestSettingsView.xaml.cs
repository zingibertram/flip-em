using Games.Core;
using System.Windows;

namespace TestGame
{
    public partial class TestSettingsView : ISettings
    {
        public TestSettingsView()
        {
            InitializeComponent();
        }

        public object Settings
        {
            get { return null; }
        }

        public FrameworkElement View
        {
            get { return this; }
        }
    }
}
