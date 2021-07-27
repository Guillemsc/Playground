using Juce.CoreUnity.Service;
using Playground.Content.Stage.Services;

namespace Playground.Cheats
{
    public static class TogglePauseCheat
    {
        public static void Execute()
        {
            bool serviceFound = ServicesProvider.TryGetService(out PauseStageService pauseStageService);

            if (!serviceFound)
            {
                return;
            }

            pauseStageService.Toggle();
        }
    }
}
