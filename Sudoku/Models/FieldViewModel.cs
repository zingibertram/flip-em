using Sudoku.Core;

namespace Sudoku.Models
{
    public class FieldViewModel
    {
        private readonly Field _source;
        private readonly Field _field;

        public FieldViewModel()
        {
            _source = FieldGenerator.Generate();
            _field = FieldStriker.StrikeOut(_source);
            FieldSolver.Solve(_field);
        }
    }
}
