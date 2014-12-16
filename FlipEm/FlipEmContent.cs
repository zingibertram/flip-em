using Games.Core;

namespace FlipEm
{
    public class FlipEmContent : IGameViews
    {
        public FlipEmContent()
        {
            _game = new FlipEmGameView();
            _settings = new FlipEmSettingsView();
        }
    }
}
