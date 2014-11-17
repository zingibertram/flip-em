using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core
{
    public delegate void GameStepEventHandler(object sender, GameStepEventArgs e);

    public class GameStepEventArgs : EventArgs
    {
        public GameStepEventArgs()
        {
        }
    }
}
