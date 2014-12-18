using Games.Core;
using System.Windows;
using Sudoku.Core;

namespace Sudoku
{
    public partial class SudokuGameView : IGame
    {
        public SudokuGameView()
        {
            InitializeComponent();

            FieldGenerator.Generate();
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
