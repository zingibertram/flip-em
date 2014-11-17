using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games.Core
{
    public interface ISettings : IView
    {
        object Settings { get; }
    }
}
