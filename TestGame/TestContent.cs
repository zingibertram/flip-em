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

        public override string Text
        {
            get { return "Test game 1.0"; }
        }

        ~TestContent()
        {
            Console.WriteLine("Test game content desttructed");
        }
    }
}
