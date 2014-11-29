using Games.Core;
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

namespace TestGame
{
    /// <summary>
    /// Interaction logic for TestGameView.xaml
    /// </summary>
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
