using Games.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GamesWpf
{
    public partial class GameWindow
    {
        public static readonly DependencyProperty GamesProperty =
            DependencyProperty.Register("Games", typeof(ObservableCollection<IGameInfo>),
            typeof(GameWindow), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentGameProperty =
            DependencyProperty.Register("CurrentGame", typeof(IGameViews),
            typeof(GameWindow), new PropertyMetadata(null));

        public GameWindow()
        {
            InitializeComponent();
            Games = GamesLoader.Load();
        }

        public ObservableCollection<IGameInfo> Games
        {
            get { return (ObservableCollection<IGameInfo>)GetValue(GamesProperty); }
            set { SetValue(GamesProperty, value); }
        }

        public IGameViews CurrentGame
        {
            get { return (IGameViews)GetValue(CurrentGameProperty); }
            set { SetValue(CurrentGameProperty, value); }
        }
        
        private void OnApplySettingsButtonClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.Settings = CurrentGame.SettingsView.Settings;
            CurrentGame.GameView.Start();

            OpenGame();
        }

        private void OnOpenSettingsClick(object sender, RoutedEventArgs e)
        {
            OpenSettings();
        }

        private void OpenSettings()
        {
            GameView.Visibility = Visibility.Collapsed;
            SettingsView.Visibility = Visibility.Visible;
        }

        private void OpenGame()
        {
            GameView.Visibility = Visibility.Visible;
            SettingsView.Visibility = Visibility.Collapsed;
        }

        private void OnGameClick(object sender, MouseButtonEventArgs e)
        {
            MainTab.IsSelected = true;
            OpenSettings();
        }

        private void OnOpenGameCkick(object sender, RoutedEventArgs e)
        {
            OpenGame();
        }

        private void OnRestartClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.Start();
        }

        private void OnUndoClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.Undo();
        }

        private void OnRedoClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.Redo();
        }

        private void OnPlayClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionStart();
        }

        private void OnPauseClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionPause();
        }

        private void OnStopClick(object sender, RoutedEventArgs e)
        {
            CurrentGame.GameView.SolutionStop();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
