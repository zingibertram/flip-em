using Games.Core;
using System;
using System.Collections.Generic;
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

namespace Games
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class GameWindow : RadRibbonWindow
    {
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
                    new FlipEm.FlipEmContent(),
                }
            };
            GamesViews.View.CurrentChanged += OnCurrentGameChanged;
        }

        public CollectionViewSource GamesViews
        {
            get { return (CollectionViewSource)GetValue(GamesViewsProperty); }
            set { SetValue(GamesViewsProperty, value); }
        }
        
        private void OnApplySettingsButtonClick(object sender, RoutedEventArgs e)
        {
            GameView.Visibility = Visibility.Visible;
            SettingsView.Visibility = Visibility.Collapsed;

            var view = (IGameViews)GamesViews.View.CurrentItem;
            view.GameView.Settings = view.SettingsView.Settings;
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

        private void OnCurrentGameChanged(object sender, EventArgs e)
        {
            MainTab.IsSelected = true;
            OpenSettings();
        }
    }
}
