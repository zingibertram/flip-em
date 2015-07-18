using System.Windows.Input;
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Threading;
using FlipEm.Core;
using Games.Core;
using System.Windows;

namespace FlipEm
{
    public partial class FlipEmGameView : IGame
    {
        private FlipEmSettings _settings;
        private IEnumerator<Point> _solutionSteps;
        private IEnumerable<Point> _solutionStepsPoints;
        private readonly DispatcherTimer _solutionTimer;

        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register("Field", typeof(Field),
            typeof(FlipEmGameView), new PropertyMetadata(null));
        
        public FlipEmGameView()
        {
            InitializeComponent();

            _solutionTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _solutionTimer.Tick += OnSolutionTimerTick;

            _settings = new FlipEmSettings { Size = 3, Step = StepType.Cross };
            StartNew();
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

        public void StartNew()
        {
            ResetField();

            _solutionStepsPoints = FlipEmSolutionLoader.GetSolution(_settings);
        }

        private void OnSolutionTimerTick(object sender, EventArgs eventArgs)
        {
            Field.ClickProgrammatically(_solutionSteps.Current);

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
