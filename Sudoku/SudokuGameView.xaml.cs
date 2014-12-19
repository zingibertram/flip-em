using System.Windows;
using Games.Core;
using Sudoku.Models;

namespace Sudoku
{
    public partial class SudokuGameView : IGame
    {
        public SudokuGameView()
        {
            InitializeComponent();

            var field = new FieldViewModel();
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
