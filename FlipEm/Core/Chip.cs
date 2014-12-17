using Games.Core;

namespace FlipEm.Core
{
    public class Chip : Changeable
    {
        private bool _isChecked;
        private readonly int _x;
        private readonly int _y;

        public Chip(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public bool IsChecked
        {
            get { return _isChecked;}
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public void Click()
        {
            IsChecked = !IsChecked;
        }

        public override string ToString()
        {
            return _isChecked ? "1" : "0";
        }
    }
}
