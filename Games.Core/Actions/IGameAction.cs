namespace Games.Core.Actions
{
    public interface IGameAction
    {
        void Redo();
        void Undo();

        string Text { get; }
    }
}
