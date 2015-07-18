namespace Games.Core
{
    public interface IGame : IView
    {
        void StartNew();
        object Settings { set; }

        void Restart();
        bool CanRestart();
        void SolutionStart();
        bool CanSolutionStart();
        void SolutionStop();
        bool CanSolutionStop();
        void SolutionPause();
        bool CanSolutionPause();
    }
}
