using System;
using System.Windows.Input;
using FlipEm.Core;
using Games.Core.Actions;

namespace FlipEm
{
    public partial class FlipEmGameView
    {
        private void OnChipClicked(object sender, ExecutedRoutedEventArgs e)
        {
            var chip = e.Parameter as Chip;
            if (chip == null)
                return;

            Field.Click(chip);

            var action = new Action(() => Field.ClickProgrammatically(chip));
            var message = string.Format("({0}, {1})", chip.X, chip.Y);
            ActionService.Instance.Add(new StepAction(message, action, action));

            e.Handled = true;
        }

        private void CanChipClicked(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Field.CanClick();
        }

        private void OnRestart(object sender, ExecutedRoutedEventArgs e)
        {
            ResetField();
            ActionService.Instance.Clear();

            e.Handled = true;
        }

        private void CanRestart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Field.CanRestart()
                || ActionService.Instance.RedoActions.Count > 0
                || ActionService.Instance.UndoActions.Count > 0;
        }

        private void OnSolutionStart(object sender, ExecutedRoutedEventArgs e)
        {
            SetStepsEnumerator();
            if (_solutionSteps != null)
            {
                ItemsPanel.IsEnabled = false;
                _solutionTimer.Start();
                ActionService.Instance.Clear();
            }

            e.Handled = true;
        }

        private void CanSolutionStart(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null
                && !_solutionTimer.IsEnabled;
        }

        private void OnSolutionPause(object sender, ExecutedRoutedEventArgs e)
        {
            _solutionTimer.Stop();

            e.Handled = true;
        }

        private void CanSolutionPause(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null
                && _solutionSteps != null
                && _solutionTimer.IsEnabled;
        }

        private void OnSolutionStop(object sender, ExecutedRoutedEventArgs e)
        {
            SolutionStop();

            e.Handled = true;
        }

        private void CanSolutionStop(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _solutionStepsPoints != null
                && _solutionSteps != null
                && _solutionTimer != null;
        }
    }
}
