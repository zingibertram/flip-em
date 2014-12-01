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
