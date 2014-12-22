using System.Windows;
using Games.Core;
using Sudoku.Models;
using Sudoku.Tests;

namespace Sudoku
{
    public partial class SudokuGameView : IGame
    {
        public SudokuGameView()
        {
            InitializeComponent();

            var field = new FieldViewModel();
            TestFieldGenerator.TestFielfdGenerator();
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
