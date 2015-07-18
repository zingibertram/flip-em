using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Games.Core;

namespace GamesWpf
{
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
            }

            e.Handled = true;
        }

        private void OnRestart(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GameView.Restart();
            e.Handled = true;
        }

        private void CanRestart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentGame != null && CurrentGame.GameView.CanRestart();
        }

        private void OnSolutionStart(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionStart();
            e.Handled = true;
        }

        private void CanSolutionStart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentGame != null && CurrentGame.GameView.CanSolutionStart();
        }

        private void OnSolutionPause(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionPause();
            e.Handled = true;
        }

        private void CanSolutionPause(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentGame != null && CurrentGame.GameView.CanSolutionPause();
        }

        private void OnSolutionStop(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionStop();
            e.Handled = true;
        }

        private void CanSolutionStop(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentGame != null && CurrentGame.GameView.CanSolutionStop();
        }
    }
}

