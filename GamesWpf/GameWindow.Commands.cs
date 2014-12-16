using System.Windows;
using System.Windows.Input;

namespace GamesWpf
{
    public static class GameWindowCommands
    {
        public static RoutedUICommand ShowGameCommand { get; private set; }
        public static RoutedUICommand ShowSettingsCommand { get; private set; }
        public static RoutedUICommand ApplySettingsCommand { get; private set; }

        static GameWindowCommands()
        {
            ShowGameCommand = new RoutedUICommand();
            ShowSettingsCommand = new RoutedUICommand();
            ApplySettingsCommand = new RoutedUICommand();
        }
    }

    public partial class GameWindow
    {
        private void OnShowGame(object sender, ExecutedRoutedEventArgs e)
        {
            OpenGame();
        }

        private void CanShowGame(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = GameView != null && GameView.Visibility != Visibility.Visible;
        }

        private void OnShowSettings(object sender, ExecutedRoutedEventArgs e)
        {
            OpenSettings();
        }

        private void CanShowSettings(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = SettingsView != null && SettingsView.Visibility != Visibility.Visible;
        }

        private void OnApplySettings(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GameView.Settings = CurrentGame.SettingsView.Settings;
            CurrentGame.GameView.StartNew();

            OpenGame();
        }

        private void OnClose(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}

