using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace Sudoku.Core
{
    public class Field
    {
        private readonly int[,] _field;

        public Field()
        {
            _field = new int[S.F, S.F];
        }

        public Field(int[,] f)
            : this()
        {
            if (f.Length != S.F * S.F)
                throw new ArgumentException();

            for (int i = 0; i < S.F; ++i)
            {
                for (int j = 0; j < S.F; ++j)
                {
                    _field[i, j] = f[i, j];
                }
            }
        }

        public Field(Field f)
            : this(f._field)
        {
        }

        public int this[int i, int j]
        {
            get { return _field[i, j]; }
            set { _field[i, j] = value; }
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var num = S.F.ToString().Length;

            var s = string.Format("{0}+-", new string('-', S.N * (num + 1)));
            var res = string.Concat(Enumerable.Repeat(s, S.N));
            var lineSep = string.Format("\n{0}", res);
            lineSep = lineSep.Remove(lineSep.Length - 3);

            var builder = new StringBuilder();

            for (int i = 0; i < S.F; i++)
            {
                for (int j = 0; j < S.F; j++)
                {
                    var v = _field[i, j];
                    builder.Append(string.Format("{0} ", v));
                    if (j % S.N == S.N - 1 && j != S.F - 1)
                    {
                        builder.Append("| ");
                    }
                }

                builder.Remove(builder.Length - 1, 1);

                if (i % S.N == S.N - 1 && i != S.F - 1)
                {
                    builder.Append(lineSep);
                }
                builder.Append("\n");
            }
            builder.Append("\n");

            return builder.ToString();
        }

        public bool IsValid()
        {
            var rows = new List<HashSet<int>>();
            var cols = new List<HashSet<int>>();
            var blos = new List<HashSet<int>>();

            for (int i = 0; i < S.F; ++i)
            {
                rows.Add(new HashSet<int>());
                cols.Add(new HashSet<int>());
                blos.Add(new HashSet<int>());
            }

            for (int i = 0; i < S.F; ++i)
            {
                for (int j = 0; j < S.F; ++j)
                {
                    var v = this[i, j];
                    if (v == 0)
                        return false;

                    rows[i].Add(v);
                    cols[j].Add(v);
                    blos[(i / S.N) * S.N + j / S.N].Add(v);
                }
            }

            for (int i = 0; i < S.F; ++i)
            {
                if (rows[i].Count != S.F
                    || cols[i].Count != S.F
                    || blos[i].Count != S.F)
                    return false;
            }

            return true;
        }
    }
}
