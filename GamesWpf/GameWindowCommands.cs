using System.Windows.Input;

namespace GamesWpf
{
    public static class GameWindowCommands
    {
        public static RoutedUICommand ShowGameCommand { get; private set; }
        public static RoutedUICommand ShowSettingsCommand { get; private set; }
        public static RoutedUICommand ApplySettingsCommand { get; private set; }
        public static RoutedUICommand OpenGameCommand { get; private set; }
        public static RoutedUICommand LoadGameCommand { get; private set; }
        public static RoutedUICommand SelectGameCommand { get; private set; }

        public static RoutedUICommand SolutionStartCommand { get; private set; }
        public static RoutedUICommand SolutionPauseCommand { get; private set; }
        public static RoutedUICommand SolutionStopCommand { get; private set; }

        public static RoutedUICommand RedoCommand { get; private set; }
        public static RoutedUICommand UndoCommand { get; private set; }
        public static RoutedUICommand RestartCommand { get; private set; }

        static GameWindowCommands()
        {
            ShowGameCommand = new RoutedUICommand();
            ShowSettingsCommand = new RoutedUICommand();
            ApplySettingsCommand = new RoutedUICommand();
            OpenGameCommand = new RoutedUICommand();
            LoadGameCommand = new RoutedUICommand();
            SelectGameCommand = new RoutedUICommand();

            SolutionStartCommand = new RoutedUICommand();
            SolutionPauseCommand = new RoutedUICommand();
            SolutionStopCommand = new RoutedUICommand();

            RedoCommand = new RoutedUICommand();
            UndoCommand = new RoutedUICommand();
            RestartCommand = new RoutedUICommand();
        }
    }
}