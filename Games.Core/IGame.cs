namespace Games.Core
{
    public interface IGame : IView
    {
        event GameStepEventHandler GameStep;
        void OnGameStep();
        void SolutionStart();
        void SolutionPause();
        void SolutionStop();
        void Redo();
        void Undo();
        void Start();
        object Settings { set; }
    }
}
