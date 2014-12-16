using System.Windows.Input;
using FlipEm.Core;

namespace FlipEm
{
    public partial class FlipEmGameView
    {
        private void OnChipClicked(object sender, ExecutedRoutedEventArgs e)
        {
            Field.Click(e.Parameter as Chip);
            e.Handled = true;
        }

        private void CanChipClicked(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Field.CanClick();
        }

        private void OnRestart(object sender, ExecutedRoutedEventArgs e)
        {
            ResetField();
        }

        private void CanRestart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Field.CanRestart();
        }

        private void OnSolutionPause(object sender, ExecutedRoutedEventArgs e)
        {
           _solutionTimer.Stop();
        }

        private void CanSolutionPause(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = _solutionStepsPoints != null && _solutionSteps != null && _solutionTimer;
        }

        private void OnSolutionStop(object sender, ExecutedRoutedEventArgs e)
        {
            SetStepsEnumerator();
            if (_solutionSteps != null)
            {
                _solutionTimer.Start();
            }
        }

        private void CanSolutionStop(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null;
        }
    }
}
