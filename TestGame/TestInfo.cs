using Games.Core;

namespace TestGame
{
    public class TestInfo : IGameInfo
    {
        public TestInfo()
        {
            _name = "Test game 1.0";
            _contentType = typeof (TestContent);
        }
    }
}
