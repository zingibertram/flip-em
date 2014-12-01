using Games.Core;

namespace FlipEm
{
    public class FlipEmInfo : IGameInfo
    {
        public FlipEmInfo()
        {
            _name = "FlipEm 3.0";
            _contentType = typeof (FlipEmContent);
        }
    }
}
