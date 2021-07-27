using Juce.CoreUnity.Service;
using Playground.Services;
using UnityEngine;

namespace Playground.Content.Stage.Services
{
    public class PauseStageService : IService
    {
        private readonly TimeService timeService;

        private bool paused;

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
            if(paused)
            {
                return;
            }

            paused = true;

            timeService.ScaledTimeContext.TimeScale = 0.0f;
            Physics.autoSimulation = false;
        }

        public void Resume()
        {
            if (!paused)
            {
                return;
            }

            paused = false;

            timeService.ScaledTimeContext.TimeScale = 1.0f;
            Physics.autoSimulation = true;
        }

        public void Toggle()
        {
            if(paused)
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
