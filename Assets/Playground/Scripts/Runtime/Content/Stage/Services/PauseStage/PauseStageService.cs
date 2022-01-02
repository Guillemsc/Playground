using Juce.CoreUnity.Service;
using Juce.CoreUnity.Time;
using Playground.Services;
using UnityEngine;

namespace Playground.Content.Stage.Services
{
    public class PauseStageService : IService
    {
        private readonly ITimeService timeService;

        public bool Paused { get; private set; }

        public PauseStageService(TimeService timeService)
        {
            this.timeService = timeService;
        }

        public void Init()
        {

        }

        public void CleanUp()
        {
          
        }

        public void Pause()
        {
            if(Paused)
            {
                return;
            }

            Paused = true;

            timeService.ScaledTimeContext.TimeScale = 0.0f;
            Physics.autoSimulation = false;
        }

        public void Resume()
        {
            if (!Paused)
            {
                return;
            }

            Paused = false;

            timeService.ScaledTimeContext.TimeScale = 1.0f;
            Physics.autoSimulation = true;
        }

        public void Toggle()
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
