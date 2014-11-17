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
        private bool _mute;

        public Chip()
        {
            PropertyChanged += OnChipPropertyChanged;
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
        
        public IEnumerable<Chip> Neighbour { get; set; }

        private void Click(bool clickSelf)
        {
            if (clickSelf)
            {
                _mute = true;
                IsChecked = !IsChecked;
                _mute = false;
            }

            foreach (var chip in Neighbour)
            {
                chip.IsChecked = !chip.IsChecked;
            }
        }

        private void OnChipPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_mute)
                return;

            if (e.PropertyName == "IsChecked")
            {
                Click()
            }
        }
    }
}
