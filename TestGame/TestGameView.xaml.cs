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

        public void SolutionStart()
        {
        }

        public void SolutionPause()
        {
        }

        public void SolutionStop()
        {
        }

        public void Redo()
        {
        }

        public void Undo()
        {
        }

        public void Start()
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
