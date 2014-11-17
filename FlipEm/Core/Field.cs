﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FlipEm.Core
{
    public class Field
    {
        private List<List<Chip>> _chips;
        private IDictionary<Chip, IEnumerable<Chip>> _neighboursByChips;

        public Field(int size, StepType type)
        {
            _chips = new List<List<Chip>>();

            List<Chip> chipsRow;
            for (int i = 0; i < size; ++i)
            {
                chipsRow = new List<Chip>();
                _chips.Add(chipsRow);
                for (int j = 0; j < size; ++j)
                {
                    chipsRow.Add(new Chip { IsChecked = false });
                }
            }

            _neighboursByChips = new Dictionary<Chip, IEnumerable<Chip>>();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    _neighboursByChips[_chips[i][j]] = NeighbourHelper.GetNeighbours(size, i, j, type)
                        .Select(p => _chips[(int)p.X][(int)p.Y]);
                }
            }
        }

        public List<List<Chip>> Chips
        {
            get { return _chips; }
        }

        public void Click(Chip chip)
        {
            foreach (var neighbourChip in _neighboursByChips[chip])
            {
                neighbourChip.IsChecked = !neighbourChip.IsChecked;
            }
        }
    }
}
