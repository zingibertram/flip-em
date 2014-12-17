using System;

namespace Games.Core.Actions
{
    public class StepAction : IGameAction
    {
        private readonly Action _undo;
        private readonly Action _redo;
        private readonly string _text;

        public StepAction(string text, Action undo, Action redo)
        {
            _undo = undo;
            _redo = redo;
            _text = text;
        }

        public void Undo()
        {
            _undo();
        }

        public void Redo()
        {
            _redo();
        }

        public string Text
        {
            get { return _text; }
        }
    }
}
