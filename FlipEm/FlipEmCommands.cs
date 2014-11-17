using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace FlipEm
{
    public static class FlipEmCommands
    {
        public static RoutedUICommand ChipClickedCommand { get; set; }

        static FlipEmCommands()
        {
            ChipClickedCommand = new RoutedUICommand();
        }
    }
}
