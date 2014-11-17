using Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlipEm
{
    public class FlipEmContent : IGameViews
    {
        private static IGame game = new FlipEmView();
        private static ISettings settings = new FlipEmSettingsView();
        private static string text = "FlipEm 3.0";

        public IGame GameView
        {
            get { return game; }
        }

        public ISettings SettingsView
        {
            get { return settings; }
        }


        public string Text
        {
            get { return text; }
        }
    }
}
