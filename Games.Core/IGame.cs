namespace Games.Core
{
    public interface IGame : IView
    {
        event GameStepEventHandler GameStep;
        void OnGameStep();
        void StartNew();
        object Settings { set; }
    }
}
