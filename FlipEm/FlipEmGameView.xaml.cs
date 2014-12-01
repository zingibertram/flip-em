using FlipEm.Core;
using Games.Core;
using System.Windows;
using System.Windows.Input;

namespace FlipEm
{
    public partial class FlipEmGameView : IGame
    {
        private FlipEmSettings _settings;
        public event GameStepEventHandler GameStep;

        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register("Field", typeof(Field),
            typeof(FlipEmGameView), new PropertyMetadata(null));
        
        public FlipEmGameView()
        {
            InitializeComponent();

            Field = new Field(6, StepType.BorderCross);
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
            ;
        }

        public void SolutionPause()
        {
            ;
        }

        public void SolutionStop()
        {
            ;
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
            Field = new Field(_settings.Size, _settings.Step);
        }

        private void OnChipClicked(object sender, ExecutedRoutedEventArgs e)
        {
            Field.Click(e.Parameter as Chip);
            e.Handled = true;
        }
    }
}
