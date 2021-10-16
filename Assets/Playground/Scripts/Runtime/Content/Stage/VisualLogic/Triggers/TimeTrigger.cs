using Juce.Core.Time;
using Juce.Core.Triggers;
using System;

namespace Playground.Content.Stage.VisualLogic.Triggers
{
    public class TimeTrigger : ITickableTrigger
    {
        private readonly ITimer timer;
        private readonly TimeSpan duration;

        private bool firstTick = true;

        public event Action OnTrigger;

        public TimeTrigger(
            ITimer timer,
            TimeSpan duration
            )
        {
            this.timer = timer;
            this.duration = duration;
        }

        public void Tick()
        {
            if(firstTick)
            {
                firstTick = false;

                timer.Start();
            }

            if(timer.Time < duration)
            {
                return;
            }

            OnTrigger?.Invoke();

            timer.Reset();
        }
    }
}
