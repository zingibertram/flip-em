using Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
