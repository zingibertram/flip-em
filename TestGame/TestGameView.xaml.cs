using Games.Core;
using System.Windows;

namespace TestGame
{
    public partial class TestGameView : IGame
    {
        public TestGameView()
        {
            InitializeComponent();
        }

        public event GameStepEventHandler GameStep;

        public void OnGameStep()
        {
        }

        public void StartNew()
        {
        }

        public object Settings
        {
            set {}
        }

        public FrameworkElement View
        {
            get { return this; }
        }
    }
}
