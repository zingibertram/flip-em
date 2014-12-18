using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FlipEm.Core
{
    public class Field
    {
        private readonly List<List<Chip>> _chips;
        private readonly IDictionary<Chip, IEnumerable<Chip>> _neighboursByChips;
        private readonly bool _isSelChecked;

        public Field(int size, StepType type)
        {
            _chips = new List<List<Chip>>();
            _isSelChecked = NeighbourHelper.IsSelfChecked(type);

            for (int i = 0; i < size; ++i)
            {
                List<Chip> chipsRow = new List<Chip>();
                _chips.Add(chipsRow);
                for (int j = 0; j < size; ++j)
                {
                    chipsRow.Add(new Chip(i, j) { IsChecked = false });
                }
            }

            _neighboursByChips = new Dictionary<Chip, IEnumerable<Chip>>();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    var neighbours = NeighbourHelper.GetNeighbours(size, i, j, type);
                    _neighboursByChips[_chips[i][j]] = neighbours.Select(GetChip);
                }
            }
        }

        public List<List<Chip>> Chips
        {
            get { return _chips; }
        }

        public bool IsSelfChecked
        {
            get { return _isSelChecked; }
        }

        public void Click(Chip chip)
        {
            foreach (var neighbourChip in _neighboursByChips[chip])
            {
                neighbourChip.Click();
            }
        }

        public void ClickProgrammatically(Chip chip)
        {
            if (!_isSelChecked)
            {
                chip.Click();
            }
            Click(chip);
        }

        public void ClickProgrammatically(Point p)
        {
            var chip = GetChip(p);
            ClickProgrammatically(chip);
        }

        public bool CanClick()
        {
            return !_chips.All(row => row.All(chip => chip.IsChecked));
        }

        public bool CanRestart()
        {
            return _chips.Any(row => row.Any(chip => chip.IsChecked));
        }

        public Chip GetChip(Point p)
        {
            return _chips[(int)p.X][(int)p.Y];
        }
    }
}
