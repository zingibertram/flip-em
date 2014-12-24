using System;
using Sudoku.Core;

namespace Sudoku.Serialization
{
    public class SerializableFieldData
    {
        public static int[] Get(FieldData fd)
        {
            var data = new int[2*S.F];

            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    data[i * S.N + j] = fd.Field[i, j];
                }
            }

            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    data[S.F + i * S.N + j] = fd.Source[i, j];
                }
            }

            return data;
        }

        public static FieldData Set(int[] data)
        {
            var field = new Field();
            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    field[i, j] = data[i * S.N + j];
                }
            }

            var source = new Field();
            for (int i = 0; i < S.N; i++)
            {
                for (int j = 0; j < S.N; j++)
                {
                    source[i, j] = data[S.F + i * S.N + j];
                }
            }

            return new FieldData(field, source);
        }
    }
}
