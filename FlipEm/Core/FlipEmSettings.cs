namespace FlipEm.Core
{
    public class FlipEmSettings
    {
        public FlipEmSettings()
        {
            Size = 3;
            Step = StepType.Cross;
        }

        public int Size { get; set; }
        public StepType Step { get; set; }
    }
}
