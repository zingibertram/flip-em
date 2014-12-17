using System.Collections.Generic;

namespace Games.Core.Actions
{
    public class ActionService : Changeable
    {
        private static readonly ActionService _instance = new ActionService();
        private static readonly object _locker = new object();
        private readonly Stack<IGameAction> _redoActions;
        private readonly Stack<IGameAction> _undoActions;

        private ActionService()
        {
            _redoActions = new Stack<IGameAction>();
            _undoActions = new Stack<IGameAction>();
        }

        public static ActionService Instance
        {
            get
            {
                lock (_locker)
                {
                    return _instance;
                }
            }
        }

        public Stack<IGameAction> RedoActions
        {
            get
            {
                lock (_locker)
                {
                    return _redoActions;
                }
            }
        }

        public Stack<IGameAction> UndoActions
        {
            get
            {
                lock (_locker)
                {
                    return _undoActions;
                }
            }
        }

        public IGameAction LastAction
        {
            get
            {
                lock (_locker)
                {
                    return _undoActions.Count > 0 ? _undoActions.Peek() : null;
                }
            }
        }

        public void Add(IGameAction action)
        {
            lock (_locker)
            {
                _redoActions.Clear();
                _undoActions.Push(action);
            }

            ActionsChanged();
        }

        public void Undo()
        {
            lock (_locker)
            {
                var action = _undoActions.Pop();
                action.Undo();
                _redoActions.Push(action);
            }

            ActionsChanged();
        }

        public void Redo()
        {
            lock (_locker)
            {
                var action = _redoActions.Pop();
                action.Redo();
                _undoActions.Push(action);
            }

            ActionsChanged();
        }

        public void Clear()
        {
            lock (_locker)
            {
                _undoActions.Clear();
                _redoActions.Clear();
            }

            ActionsChanged();
        }

        private void ActionsChanged()
        {
            OnPropertyChanged("LastAction");
            OnPropertyChanged("UndoActions");
            OnPropertyChanged("RedoActions");   
        }
    }
}
