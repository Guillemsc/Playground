using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.Triggers;
using System.Collections.Generic;

namespace Playground.Content.Stage.VisualLogic.Tickables
{
    public class TimeTriggersTickable : ITickable
    {
        private readonly List<TimeTrigger> toAdd = new List<TimeTrigger>();
        private readonly List<TimeTrigger> toRemove = new List<TimeTrigger>();

        private readonly List<TimeTrigger> timeTriggers = new List<TimeTrigger>();

        public void Tick()
        {
            foreach (TimeTrigger timeTrigger in toAdd)
            {
                timeTriggers.Add(timeTrigger);
            }

            foreach (TimeTrigger timeTrigger in timeTriggers)
            {
                timeTrigger.Tick();
            }

            foreach(TimeTrigger timeTrigger in toRemove)
            {
                timeTriggers.Remove(timeTrigger);
            }

            toAdd.Clear();
            toRemove.Clear();
        }

        public void Add(TimeTrigger trigger)
        {
            toAdd.Add(trigger);
        }

        public void Remove(TimeTrigger trigger)
        {
            toRemove.Remove(trigger);
        }
    }
}
