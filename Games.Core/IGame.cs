using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core
{
    public interface IGame
    {
        event GameStepEventHandler GameStep;
        void OnGameStep();
        void SolutionStart();
        void SolutionPause();
        void SolutionStop();
        void Redo();
        void Undo();
    }
}
