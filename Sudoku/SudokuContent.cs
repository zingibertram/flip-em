using Games.Core;

namespace Sudoku
{
    public class SudokuContent : IGameViews
    {
        public SudokuContent()
        {
            _settings = new SudokuSettingsView();
            _game = new SudokuGameView();
        }
    }
}
