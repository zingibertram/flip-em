using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games.Core
{
    public interface IGameViews
    {
        IGame GameView { get; }
        ISettings SettingsView { get; }
        string Text { get; }
    }
}
