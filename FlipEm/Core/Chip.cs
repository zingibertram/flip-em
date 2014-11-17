using Games.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
    }
}
