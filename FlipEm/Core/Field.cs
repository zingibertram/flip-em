using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlipEm.Core
{
    public class Field : List<List<Chip>>
    {
        public Field(int size, StepType type)
        {
            List<Chip> chips;
            for (int i = 0; i < size; ++i)
            {
                chips = new List<Chip>();
                Add(chips);
                for (int j = 0; j < size; ++j)
                {
                    chips.Add(new Chip { IsChecked = false });
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    this[i][j].Neighbour = NeighbourHelper.GetNeighbours(size, i, j, type).Select(p => this[(int)p.X][(int)p.Y]);
                }
            }
        }
    }
}
