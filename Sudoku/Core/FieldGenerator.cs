using System;
using System.Collections.Generic;
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

        public static Field Generate(int num = 10)
        {
            _field = new Field();
            var rng = Enumerable.Range(0, S.F).ToList();
            foreach (var k in rng)
            {
                foreach (var l in rng)
                {
                    var i = k + 1;
                    var j = l + 1;
                    _field[k, l] = (i * S.N + i / S.N + j) % S.F + 1;
                }
            }

            Mix(num);

            return new Field(_field);
        }

        private static void Transposing()
        {
            for (int i = 0; i < S.F; ++i)
            {
                for (int j = 0; j < S.F; ++j)
                {
                    var tmp = _field[i, j];
                    _field[i, j] = _field[j, i];
                    _field[j, i] = tmp;
                }
            }
        }

        private static void SwapRows(int i, int j)
        {
            for (int k = 0; k < S.F; ++k)
            {
                var tmp = _field[k, i];
                _field[k, i] = _field[k, j];
                _field[k, j] = tmp;
            }
        }

        private static void SwapColumns(int i, int j)
        {
            for (int k = 0; k < S.F; ++k)
            {
                var tmp = _field[i, k];
                _field[i, k] = _field[j, k];
                _field[j, k] = tmp;
            }
        }

        private static int[] GetPair(bool addArea = true)
        {
            var p = new[] { _rand.Next(0, S.N), _rand.Next(0, S.N) };
            while (p[0] == p[1])
            {
                p[1] = _rand.Next(0, S.N);
            }

            if (addArea)
            {
                var area = _rand.Next(0, S.N);
                p[0] += area * S.N;
                p[1] += area * S.N;
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
            p = new[] { p[0] * S.N, p[1] * S.N};
            for (int i = 0; i < S.N; ++i)
            {
                SwapRows(p[0] + i, p[1] + i);
            }
        }

        private static void SwapAreasColumns()
        {
            var p = GetPair(false);
            p = new[] { p[0] * S.N, p[1] * S.N};
            for (int i = 0; i < S.N; ++i)
            {
                SwapColumns(p[0] + i, p[1] + i);
            }
        }

        private static void Mix(int num)
        {
            for (int i = 0; i < num; ++i)
            {
                var k = _rand.Next(0, _mixActions.Count);
                _mixActions[k]();
            }
        }
    }

    public class FieldStriker
    {
        private static Field _field;

        public static Field StrikeOut(Field f)
        {
            _field = f;

            //var look = new bool[S.N, S.N];
            //for (int i = 0; i < S.F; ++i)
            //{
            //    for (int j = 0; j < S.F; ++j)
            //    {
            //        look[i, j] = false;
            //    }
            //}

            //var iter = 0;
            //var difficult = S.F*S.F;

            //while (iter < S.F*S.F)
            //{

            //}
            return null;
        }
    }
}
