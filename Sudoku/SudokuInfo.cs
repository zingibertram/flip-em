using Games.Core;

namespace Sudoku
{
    public class SudokuInfo : IGameInfo
    {
        public SudokuInfo()
        {
            _name = "Sudoku 1.0";
            _contentType = typeof(SudokuContent);
        }
    }
}
