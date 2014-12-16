using System.Windows.Input;

namespace Games.Core
{
    public static class GameCommands
    {
        public static RoutedUICommand SolutionStartCommand { get; private set; }
        public static RoutedUICommand SolutionPauseCommand { get; private set; }
        public static RoutedUICommand SolutionStopCommand { get; private set; }

        public static RoutedUICommand RedoCommand { get; private set; }
        public static RoutedUICommand UndoCommand { get; private set; }
        public static RoutedUICommand RestartCommand { get; private set; }

        static GameCommands()
        {
            SolutionStartCommand = new RoutedUICommand();
            SolutionPauseCommand = new RoutedUICommand();
            SolutionStopCommand = new RoutedUICommand();

            RedoCommand = new RoutedUICommand();
            UndoCommand = new RoutedUICommand();
            RestartCommand = new RoutedUICommand();
        }
    }
}
