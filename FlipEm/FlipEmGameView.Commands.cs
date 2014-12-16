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

        private void OnSolutionStart(object sender, ExecutedRoutedEventArgs e)
        {
            SetStepsEnumerator();
            if (_solutionSteps != null)
            {
                ItemsPanel.IsEnabled = false;
                _solutionTimer.Start();
            }
        }

        private void CanSolutionStart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null && !_solutionTimer.IsEnabled;
        }

        private void OnSolutionPause(object sender, ExecutedRoutedEventArgs e)
        {
           _solutionTimer.Stop();
        }

        private void OnSolutionStop(object sender, ExecutedRoutedEventArgs e)
        {
            SolutionStop();
        }

        private void CanSolutionPauseStop(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null && _solutionSteps != null && _solutionTimer.IsEnabled;
        }
    }
}
