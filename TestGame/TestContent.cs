using Games.Core;
using System;

namespace TestGame
{
    public class TestContent : IGameViews
    {
        public TestContent()
        {
            _settings = new TestSettingsView();
            _game = new TestGameView();
        }
    }
}
