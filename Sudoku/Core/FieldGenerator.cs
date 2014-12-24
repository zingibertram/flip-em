using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Sudoku.Core
{
    public class FieldGenerator
    {
        private static readonly Random _rand = new Random();
        private static Field _field;

        private static readonly List<Action> _mixActions = new List<Action>
        {
            Transposing, SwapRowsInArea, SwapColumnsInArea, SwapAreasRows, SwapAreasColumns
        };

        public static Field Generate(int num = 16)
        {
            _field = new Field();
            var rng = Enumerable.Range(0, S.N).ToList();
            foreach (var i in rng)
            {
                foreach (var j in rng)
                {
                    _field[i, j] = (i * S.B + i / S.B + j) % S.N + 1;
                }
            }

            Mix(num);

            return new Field(_field);
        }

        private static void Transposing()
        {
            for (int i = 0; i < S.N; ++i)
            {
                for (int j = 0; j < S.N; ++j)
                {
                    var tmp = _field[i, j];
                    _field[i, j] = _field[j, i];
                    _field[j, i] = tmp;
                }
            }
        }

        private static void SwapRows(int i, int j)
        {
            for (int k = 0; k < S.N; ++k)
            {
                var tmp = _field[k, i];
                _field[k, i] = _field[k, j];
                _field[k, j] = tmp;
            }
        }

        private static void SwapColumns(int i, int j)
        {
            for (int k = 0; k < S.N; ++k)
            {
                var tmp = _field[i, k];
                _field[i, k] = _field[j, k];
                _field[j, k] = tmp;
            }
        }

        private static int[] GetPair(bool addArea = true)
        {
            var p = new[] { _rand.Next(0, S.B), _rand.Next(0, S.B) };
            while (p[0] == p[1])
            {
                p[1] = _rand.Next(0, S.B);
            }

            if (addArea)
            {
                var area = _rand.Next(0, S.B);
                p[0] += area * S.B;
                p[1] += area * S.B;
            }

            return p;
        }

        private static void SwapRowsInArea()
        {
            var p = GetPair();
            SwapRows(p[0], p[1]);
        }

        private static void SwapColumnsInArea()
        {
            var p = GetPair();
            SwapColumns(p[0], p[1]);
        }

        private static void SwapAreasRows()
        {
            var p = GetPair(false);
            for (int i = 0; i < S.B; ++i)
            {
                SwapRows(p[0] * S.B + i, p[1] * S.B + i);
            }
        }

        private static void SwapAreasColumns()
        {
            var p = GetPair(false);
            for (int i = 0; i < S.B; ++i)
            {
                SwapColumns(p[0] * S.B + i, p[1] * S.B + i);
            }
        }

        private static void Mix(int num)
        {
            for (int i = 0; i < num; ++i)
            {
                var k = _rand.Next(0, _mixActions.Count);
                _mixActions[k]();

                if (!_field.IsValid())
                {
                    throw new InvalidConstraintException(_field.ToString());
                }
            }
        }
    }

    public class FieldStriker
    {
        private static readonly Random _rand = new Random();

        public static Field StrikeOut(Field f)
        {
            var field = new Field(f);

            var look = new bool[S.N, S.N];
            for (int i = 0; i < S.N; ++i)
            {
                for (int j = 0; j < S.N; ++j)
                {
                    look[i, j] = false;
                }
            }

            var iter = 0;
            var difficult = S.N * S.N;

            FieldSolver.iterCnt = 0;
            while (iter < S.N * S.N)
            {
                var i = _rand.Next(0, S.N);
                var j = _rand.Next(0, S.N);

                if (!look[i, j])
                {
                    iter++;
                    look[i, j] = true;

                    var tmp = field[i, j];
                    field[i, j] = 0;
                    difficult--;

                    var resolved = new Field(field);
                    var solutionCount = FieldSolver.Solve(resolved).Count();
                    if (solutionCount > 1)
                    {
                        field[i, j] = tmp;
                        difficult++;
                    }
                }
            }
            return f;
        }
    }
}
