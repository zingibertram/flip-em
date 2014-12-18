using Games.Core;
using System.Windows;

namespace Sudoku
{
    public partial class SudokuSettingsView : ISettings
    {
        public SudokuSettingsView()
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
