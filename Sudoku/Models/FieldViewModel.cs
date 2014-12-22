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
            _source.WriteToConsole();
            _field = FieldStriker.StrikeOut(_source);

            //_field = new Field(new int[,]
            //    {{5, 3, 0, 0, 7, 0, 0, 0, 0},
            //     {6, 0, 0, 1, 9, 5, 0, 0, 0},
            //     {0, 9, 8, 0, 0, 0, 0, 6, 0},
            //     {8, 0, 0, 0, 6, 0, 0, 0, 3},
            //     {4, 0, 0, 8, 0, 3, 0, 0, 1},
            //     {7, 0, 0, 0, 2, 0, 0, 0, 6},
            //     {0, 6, 0, 0, 0, 0, 2, 8, 0},
            //     {0, 0, 0, 4, 1, 9, 0, 0, 5},
            //     {0, 0, 0, 0, 8, 0, 0, 7, 9}});
            //foreach (var s in FieldSolver.Solve(_field))
            //{
            //    s.WriteToConsole();
            //};
        }
    }
}
