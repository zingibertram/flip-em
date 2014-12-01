using System;

namespace Games.Core
{
    public delegate void GameStepEventHandler(object sender, GameStepEventArgs e);

    public class GameStepEventArgs : EventArgs
    {
        public GameStepEventArgs(int num, string msg)
        {
            StepNumber = num;
            StepMessage = msg;
        }

        public int StepNumber { get; private set; }
        public string StepMessage { get; private set; }
    }
}
