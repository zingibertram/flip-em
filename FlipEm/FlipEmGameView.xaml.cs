using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Threading;
using FlipEm.Core;
using Games.Core;
using System.Windows;
using System.Windows.Input;

namespace FlipEm
{
    public partial class FlipEmGameView : IGame
    {
        private FlipEmSettings _settings;
        private IEnumerator<Point> _solutionSteps;
        private IEnumerable<Point> _solutionStepsPoints;
        private readonly DispatcherTimer _solutionTimer;

        public event GameStepEventHandler GameStep;

        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register("Field", typeof(Field),
            typeof(FlipEmGameView), new PropertyMetadata(null));
        
        public FlipEmGameView()
        {
            InitializeComponent();

            _solutionTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _solutionTimer.Tick += OnSolutionTimerTick;

            _settings = new FlipEmSettings { Size = 3, Step = StepType.Cross };
            Start();
        }

        public Field Field
        {
            get { return (Field)GetValue(FieldProperty); }
            private set { SetValue(FieldProperty, value); }
        }

        public FrameworkElement View
        {
            get { return this; }
        }
        
        public object Settings
        {
            set { _settings = (FlipEmSettings)value; }
        }

        public void OnGameStep()
        {
            ;
        }

        public void SolutionStart()
        {
            SetStepsEnumerator();
            if (_solutionSteps != null)
            {
                _solutionTimer.Start();
            }
        }

        public void SolutionPause()
        {
            _solutionTimer.Stop();
        }

        public void SolutionStop()
        {
            _solutionTimer.Stop();
            _solutionSteps = null;
        }

        public void Redo()
        {
            ;
        }

        public void Undo()
        {
            ;
        }

        public void Start()
        {
            ResetField();

            var propertyName = string.Format("{0}_{1}", _settings.Step.ToString(), _settings.Size);

            var type = typeof(Res.Resource);
            var property = type.GetProperty(propertyName);

            _solutionStepsPoints = null;

            if (property != null)
            {
                var solution = property.GetValue(null, null) as string;
                if (string.IsNullOrEmpty(solution))
                    return;

                using (var reader = new StringReader(solution))
                {
                    var steps = new List<Point>();

                    var num = int.Parse(reader.ReadLine());
                    for (int i = 0; i < num; ++i)
                    {
                        var row = reader.ReadLine().Split(' ');
                        steps.Add(new Point(int.Parse(row[0]), int.Parse(row[1])));
                    }

                    _solutionStepsPoints = steps;
                }
            }
        }

        private void OnChipClicked(object sender, ExecutedRoutedEventArgs e)
        {
            Field.Click(e.Parameter as Chip);
            e.Handled = true;
        }

        private void CanChipClicked(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Field.CanClick();
        }

        private void OnSolutionTimerTick(object sender, EventArgs eventArgs)
        {
            var chip = Field.Chips[(int)_solutionSteps.Current.X][(int)_solutionSteps.Current.Y];
            if (NeighbourHelper.IsSelfChecked(_settings.Step))
            {
                chip.IsChecked = !chip.IsChecked;
            }

            Field.Click(chip);

            if (!_solutionSteps.MoveNext())
            {
                SolutionStop();
            }
        }

        private void SetStepsEnumerator()
        {
            if (_solutionSteps != null)
                return;

            if (_solutionStepsPoints != null)
            {
                ResetField();
                _solutionSteps = _solutionStepsPoints.GetEnumerator();
                _solutionSteps.MoveNext();
            }
        }

        private void ResetField()
        {
            Field = new Field(_settings.Size, _settings.Step);
        }
    }
}
