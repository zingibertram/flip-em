using FlipEm;
using Games.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using TestGame;

namespace Games
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class GameWindow : RadRibbonWindow
    {
        private string _currentStyle;
        private static List<string> _styles = new List<string>
        {
            "ExpressionDark", "Office2013", "OfficeBlack", "OfficeBlue",
            "OfficeSilver", "Summer", "Tranceparent", "Vista",
            "VisualStudio2013", "Windows7", "Windows8", "Windows8Touch"
        };

        private static List<string> _styleDicts = new List<string>
        {
            "System.Windows.xaml", "Telerik.Windows.Controls.xaml", "Telerik.Windows.Controls.Input.xaml",
            "Telerik.Windows.Controls.Navigation.xaml", "Telerik.Windows.Controls.RibbonView.xaml"
        };

        public static readonly DependencyProperty GamesViewsProperty =
            DependencyProperty.Register("GamesViews", typeof(CollectionViewSource),
            typeof(GameWindow), new PropertyMetadata(null));

        public GameWindow()
        {
            InitializeComponent();

            GamesViews = new CollectionViewSource
            {
                Source = new List<IGameViews>
                {
                    new FlipEmContent(),
                    new TestContent(),
                }
            };
            GamesViews.View.CurrentChanged += OnCurrentGameChanged;
        }

        public CollectionViewSource GamesViews
        {
            get { return (CollectionViewSource)GetValue(GamesViewsProperty); }
            set { SetValue(GamesViewsProperty, value); }
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

            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.Settings = view.SettingsView.Settings;
            view.GameView.Start();
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

        private void OnCurrentGameChanging(object sender, CurrentChangingEventArgs e)
        {
        }

        private void OnCurrentGameChanged(object sender, EventArgs e)
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

            string file;
            foreach (var sfile in _styleDicts)
            {
                file = string.Format("pack://application:,,,/Themes/{0}/{1}", style, sfile);
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(file)
                });
            }
        }

        private void OnRestartClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.Start();
        }

        private void OnUndoClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.Undo();
        }

        private void OnRedoClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.Redo();
        }

        private void OnPlayClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.SolutionStart();
        }

        private void OnPauseClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.SolutionPause();
        }

        private void OnStopClick(object sender, RoutedEventArgs e)
        {
            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.SolutionStop();
        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
