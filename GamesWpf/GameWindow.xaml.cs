using Games.Core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Games.Core.Actions;
using Microsoft.Win32;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;

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
            foreach (var g in Games)
            {
                AddGamesMenuItem(g);
            }
            SetStartGame();
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

        public ActionService ActionService
        {
            get { return ActionService.Instance; }
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

        private void OnSolutionTabVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            OpenGame();
        }

        private void AddGamesMenuItem(IGameInfo g)
        {
            GamesMenu.Items.Add(new RibbonApplicationMenuItem
            {
                Header = g.Name,
                Command = GameWindowCommands.SelectGameCommand,
                CommandParameter = g
            });
        }

        private void SetStartGame()
        {
            if (Games.Count > 0)
            {
                var game = Games[0];
                SetCurrent(game);
            }
        }

        private void SetCurrent(IGameInfo game)
        {
            var converter = new TypeToGameConverter();
            CurrentGame = converter.ConvertBack(game, null, null, null) as IGameViews;
        }
    }
}

