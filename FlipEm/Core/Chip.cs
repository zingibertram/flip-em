using Games.Core;

namespace FlipEm.Core
{
    public class Chip : Changeable
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked;}
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public override string ToString()
        {
            return _isChecked ? "1" : "0";
        }
    }
}
