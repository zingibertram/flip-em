using Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public override string Text
        {
            get { return "FlipEm 3.0"; }
        }

        ~FlipEmContent()
        {
            Console.WriteLine("FlipEm game content desttructed");
        }
    }
}
