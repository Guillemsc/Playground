using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Playground.Content.Stage.Services;
using Playground.Contexts;
using UnityEngine;

namespace Playground.Cheats
{
    public static class TogglePauseCheat
    {
        public static void Execute()
        {
            bool serviceFound = ServicesProvider.TryGetService(out PauseStageService pauseStageService);
            bool contextFound = ContextsProvider.TryGetContext(out StageContext stageContext);

            if (!serviceFound)
            {
                return;
            }

            if(!contextFound)
            {
                return;
            }

            pauseStageService.Toggle();

            if(pauseStageService.Paused)
            {
                stageContext.StageContextReferences.FollowCarVirtualCamera.gameObject.SetActive(false);
                stageContext.StageContextReferences.MainCamera.gameObject.AddComponent<FlyCameraCheat>();
            }
            else
            {
                stageContext.StageContextReferences.FollowCarVirtualCamera.gameObject.SetActive(true);
                FlyCameraCheat flyCameraCheat = stageContext.StageContextReferences.MainCamera.gameObject.GetComponent<FlyCameraCheat>();
                MonoBehaviour.Destroy(flyCameraCheat);
            }
        }
    }
}
