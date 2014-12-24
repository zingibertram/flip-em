using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    [Serializable]
    public class Field
    {
        private readonly int[,] _field;

        public Field()
        {
            _field = new int[S.N, S.N];
        }

        public Field(int[,] f)
            : this()
        {
            if (f.Length != S.N * S.N)
                throw new ArgumentException();

            for (int i = 0; i < S.N; ++i)
            {
                for (int j = 0; j < S.N; ++j)
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
            var num = S.N.ToString().Length;

            var s = string.Format("{0}+-", new string('-', S.B * (num + 1)));
            var res = string.Concat(Enumerable.Repeat(s, S.B));
            var lineSep = string.Format("\n{0}", res);
            lineSep = lineSep.Remove(lineSep.Length - 3);

            var builder = new StringBuilder();

            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    var v = _field[i, j];
                    builder.Append(string.Format("{0} ", v));
                    if (j % S.B == S.B - 1 && j != S.N - 1)
                    {
                        builder.Append("| ");
                    }
                }

                builder.Remove(builder.Length - 1, 1);

                if (i % S.B == S.B - 1 && i != S.N - 1)
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

            for (int i = 0; i < S.N; ++i)
            {
                rows.Add(new HashSet<int>());
                cols.Add(new HashSet<int>());
                blos.Add(new HashSet<int>());
            }

            for (int i = 0; i < S.N; ++i)
            {
                for (int j = 0; j < S.N; ++j)
                {
                    var v = this[i, j];
                    if (v == 0)
                        return false;

                    rows[i].Add(v);
                    cols[j].Add(v);
                    blos[(i / S.B) * S.B + j / S.B].Add(v);
                }
            }

            for (int i = 0; i < S.N; ++i)
            {
                if (rows[i].Count != S.N
                    || cols[i].Count != S.N
                    || blos[i].Count != S.N)
                    return false;
            }

            return true;
        }

        public int[,] GetFieldCopy()
        {
            var copy = new int[S.N, S.N];
            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    copy[i, j] = _field[i, j];
                }
            }
            return copy;
        }
    }
}
