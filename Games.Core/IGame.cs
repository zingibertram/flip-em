namespace Games.Core
{
    public interface IGame : IView
    {
        void StartNew();
        object Settings { set; }
    }
}
