using Juce.Core.Time;
using Juce.CoreUnity.Service;
using UnityEngine;

namespace Playground.Services
{
    public class TimeService : IUpdatableService
    {
        private readonly TickableTimeContext unscaledTimeContext = new TickableTimeContext();
        private readonly TickableTimeContext scaledTimeContext = new TickableTimeContext();

        public ITimeContext UnscaledTimeContext => unscaledTimeContext;
        public ITimeContext ScaledTimeContext => scaledTimeContext;

        public void Init()
        {
           
        }

        public void CleanUp()
        {
            
        }

        public void Update()
        {
            unscaledTimeContext.Tick(Time.unscaledDeltaTime);
            scaledTimeContext.Tick(Time.unscaledDeltaTime);
        }
    }
}
