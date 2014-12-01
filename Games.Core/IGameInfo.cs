using System;

namespace Games.Core
{
    public class IGameInfo
    {
        protected string _name;
        protected Type _contentType;

        public string Name
        {
            get { return _name; }
        }

        public Type ContentType
        {
            get { return _contentType; }
        }
    }
}
