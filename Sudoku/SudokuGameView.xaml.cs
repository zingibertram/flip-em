using System.Windows;
using Games.Core;
using Sudoku.Core;
using Sudoku.Models;

namespace Sudoku
{
    public partial class SudokuGameView : IGame
    {
        public SudokuGameView()
        {
            InitializeComponent();

            Generator.Generate();
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
