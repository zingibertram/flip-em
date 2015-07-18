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

        public void Restart()
        {
            ResetField();
            ActionService.Instance.Clear();
        }

        public bool CanRestart()
        {
            return Field.CanRestart()
                || ActionService.Instance.RedoActions.Count > 0
                || ActionService.Instance.UndoActions.Count > 0;
        }

        public void SolutionStart()
        {
            SetStepsEnumerator();
            if (_solutionSteps != null)
            {
                //ItemsPanel.IsEnabled = false;
                _solutionTimer.Start();
                ActionService.Instance.Clear();
            }
        }

        public bool CanSolutionStart()
        {
            return _solutionStepsPoints != null
                && !_solutionTimer.IsEnabled;
        }

        public void SolutionPause()
        {
            _solutionTimer.Stop();
        }

        public bool CanSolutionPause()
        {
            return _solutionStepsPoints != null
                && _solutionSteps != null
                && _solutionTimer.IsEnabled;
        }

        public void SolutionStop()
        {
            _solutionTimer.Stop();
            _solutionSteps = null;
            ItemsPanel.IsEnabled = true;
        }

        public bool CanSolutionStop()
        {
            return _solutionStepsPoints != null
                && _solutionSteps != null
                && _solutionTimer != null;
        }
    }
}
