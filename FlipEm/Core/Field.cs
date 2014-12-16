using System.Collections.Generic;
using System.Linq;

namespace FlipEm.Core
{
    public class Field
    {
        private readonly List<List<Chip>> _chips;
        private readonly IDictionary<Chip, IEnumerable<Chip>> _neighboursByChips;

        public Field(int size, StepType type)
        {
            _chips = new List<List<Chip>>();

            for (int i = 0; i < size; ++i)
            {
                List<Chip> chipsRow = new List<Chip>();
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

        public bool CanClick()
        {
            return !_chips.Aggregate(true,
                (acc, row) => row.Aggregate(acc,
                    (res, chip) => res && chip.IsChecked));
        }
    }
}
