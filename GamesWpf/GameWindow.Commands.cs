using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Games.Core;

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

        static GameWindowCommands()
        {
            ShowGameCommand = new RoutedUICommand();
            ShowSettingsCommand = new RoutedUICommand();
            ApplySettingsCommand = new RoutedUICommand();
            OpenGameCommand = new RoutedUICommand();
            LoadGameCommand = new RoutedUICommand();
            SelectGameCommand = new RoutedUICommand();
        }
    }

    public partial class GameWindow
    {
        private void OnShowGame(object sender, ExecutedRoutedEventArgs e)
        {
            OpenGame();

            e.Handled = true;
        }

        private void CanShowGame(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = GameView != null && GameView.Visibility != Visibility.Visible;
        }

        private void OnShowSettings(object sender, ExecutedRoutedEventArgs e)
        {
            OpenSettings();

            e.Handled = true;
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

            e.Handled = true;
        }

        private void OnClose(object sender, ExecutedRoutedEventArgs e)
        {
            Close();

            e.Handled = true;
        }

        private void OnRedo(object sender, ExecutedRoutedEventArgs e)
        {
            ActionService.Redo();

            e.Handled = true;
        }

        private void CanRedo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ActionService.RedoActions.Count > 0;
        }

        private void OnUndo(object sender, ExecutedRoutedEventArgs e)
        {
            ActionService.Undo();

            e.Handled = true;
        }

        private void CanUndo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ActionService.UndoActions.Count > 0;
        }

        private void OnOpenGame(object sender, ExecutedRoutedEventArgs e)
        {
            MainTab.IsSelected = true;
            OpenSettings();

            e.Handled = true;
        }

        private void OnLoadGame(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                CheckFileExists = true,
                Filter = "Библиотека игр|*.dll"
            };

            if (dialog.ShowDialog() == true)
            {
                var game = GamesLoader.LoadGame(dialog.FileName);
                Games.Add(game);
                AddGamesMenuItem(game);
            }

            e.Handled = true;
        }

        private void OnSelectGame(object sender, ExecutedRoutedEventArgs e)
        {
            var game = e.Parameter as IGameInfo;
            if (game != null)
            {
                SetCurrent(game);
            }
        }
    }
}

