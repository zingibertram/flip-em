using FlipEm;
using Games.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TestGame;

namespace GamesWpf
{
    public partial class GameWindow
    {
        private string _currentStyle;
        private static readonly List<string> _styles = new List<string>
        {
            "ExpressionDark", "Office2013", "OfficeBlack", "OfficeBlue",
            "OfficeSilver", "Summer", "Tranceparent", "Vista",
            "VisualStudio2013", "Windows7", "Windows8", "Windows8Touch"
        };

        private static readonly List<string> _styleDicts = new List<string>
        {
            "System.Windows.xaml", "Telerik.Windows.Controls.xaml", "Telerik.Windows.Controls.Input.xaml",
            "Telerik.Windows.Controls.Navigation.xaml", "Telerik.Windows.Controls.RibbonView.xaml"
        };

        public static readonly DependencyProperty GamesProperty =
            DependencyProperty.Register("Games", typeof(ObservableCollection<Type>),
            typeof(GameWindow), new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentGameProperty =
            DependencyProperty.Register("CurrentGame", typeof(IGameViews),
            typeof(GameWindow), new PropertyMetadata(null));

        public GameWindow()
        {
            InitializeComponent();

            Games = new ObservableCollection<Type>
            {
                typeof(FlipEmContent),
                typeof(TestContent),
            };
            CurrentGame = (IGameViews)Activator.CreateInstance(Games[0]);
        }

        public ObservableCollection<Type> Games
        {
            get { return (ObservableCollection<Type>)GetValue(GamesProperty); }
            set { SetValue(GamesProperty, value); }
        }

        public IGameViews CurrentGame
        {
            get { return (IGameViews)GetValue(CurrentGameProperty); }
            set { SetValue(CurrentGameProperty, value); }
        }

        public List<string> Styles
        {
            get { return _styles; }
        }

        public string CurrentStyle
        {
            get { return _currentStyle; }
            set
            {
                _currentStyle = value;
                if (value != null)
                {
                    ChangeStyle(value);
                }
            }
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

        private void ChangeStyle(string style)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            foreach (var sfile in _styleDicts)
            {
                var file = string.Format(@"/GamesWpf;component/Themes/{0}/{1}", style, sfile);
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(file, UriKind.Relative)
                });
            }
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
