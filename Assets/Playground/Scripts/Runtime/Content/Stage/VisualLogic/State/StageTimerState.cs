using Juce.Core.Time;

namespace Playground.Content.Stage.VisualLogic.View.Signals
{
    public class StageTimerState
    {
        public ITimer Timer { get; }

        public StageTimerState(ITimer timer)
        {
            Timer = timer;
        }
    }
}
