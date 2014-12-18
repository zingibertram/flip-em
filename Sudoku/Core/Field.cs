using System;

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
            for (int i = 0; i < S.F; i++)
            {
                for (int j = 0; j < S.F; j++)
                {
                    Console.Write(_field[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
