using Games.Core;
using System;

namespace FlipEm
{
    public class FlipEmContent : IGameViews
    {
        public FlipEmContent()
        {
            _game = new FlipEmGameView();
            _settings = new FlipEmSettingsView();
            Console.WriteLine("FlipEm game created");
        }

        ~FlipEmContent()
        {
            Console.WriteLine("FlipEm game content desttructed");
        }
    }
}
