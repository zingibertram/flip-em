namespace Games.Core
{
    public class IGameViews
    {
        protected ISettings _settings;
        protected IGame _game;

        public IGame GameView
        {
            get { return _game; }
        }

        public ISettings SettingsView
        {
            get { return _settings; }
        }

        public string Title { get; set; }
    }
}
