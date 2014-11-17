using FlipEm.Core;
using Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlipEm
{
    /// <summary>
    /// Логика взаимодействия для FlipEmView.xaml
    /// </summary>
    public partial class FlipEmView : UserControl, IGame
    {
        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register("Field", typeof(Field), typeof(FlipEmView), new PropertyMetadata(null));
        
        public FlipEmView()
        {
            InitializeComponent();

            Field = new Field(10, StepType.Cross);
        }

        public Field Field
        {
            get { return (Field)GetValue(FieldProperty); }
            set { SetValue(FieldProperty, value); }
        }

        public event GameStepEventHandler GameStep;

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
    }
}
