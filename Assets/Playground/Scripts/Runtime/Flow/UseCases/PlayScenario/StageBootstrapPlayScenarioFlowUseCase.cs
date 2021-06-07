using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Scenes;
using Playground.Configuration.Stage;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Contexts;
using Playground.Flow.Data;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playground.Flow.UseCases
{
    public class StageBootstrapPlayScenarioFlowUseCase : IPlayScenarioFlowUseCase
    {
        private readonly CurrentStageFlowData currentStageFlowData;

        public StageBootstrapPlayScenarioFlowUseCase(CurrentStageFlowData currentStageFlowData)
        {
            this.currentStageFlowData = currentStageFlowData;
        }

        public async Task Execute(ILoadingToken loadingToken)
        {
            if (currentStageFlowData.StageConfiguration == null)
            {
                UnityEngine.Debug.LogError($"No stage configuration set on {nameof(CurrentStageFlowData)}, " +
                    $"at {nameof(StageBootstrapPlayScenarioFlowUseCase)}");

                return;
            }

            StageConfiguration stageConfiguration = currentStageFlowData.StageConfiguration;

            GC.Collect();

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageUIContext.SceneName,
                StageContext.SceneName
                );

            await stageScenesLoader.Load();

            string sceneName = Path.GetFileNameWithoutExtension(stageConfiguration.StageSceneReference.ScenePath);

            SceneLoadResult sceneLoadResult = await stageScenesLoader.LoadScene(
                sceneName, 
                LoadSceneMode.Additive
                );

            if (!sceneLoadResult.Success)
            {
                UnityEngine.Debug.LogError($"Stage scene with path {stageConfiguration.StageSceneReference.ScenePath} could not be loaded, " +
                    $"at {nameof(StageBootstrapPlayScenarioFlowUseCase)}");
                return;
            }

            ScenesLoader.SetActiveScene(sceneName);

            bool found = TryGetStageView(sceneLoadResult.Scene, out StageView stageView);

            if(!found)
            {
                UnityEngine.Debug.LogError($"Stage scene with path {stageConfiguration.StageSceneReference.ScenePath} does not contain a" +
                    $"{nameof(StageView)} component on one of its roots game objects, and the stage cannot be played, " +
                    $"at {nameof(StageBootstrapPlayScenarioFlowUseCase)}");
            }

            StageUIContext stageUIContext = ContextsProvider.GetContext<StageUIContext>();
            StageContext stageContext = ContextsProvider.GetContext<StageContext>();

            stageContext.RunStage(
                stageUIContext,
                stageView,
                loadingToken
                );
        }

        public bool TryGetStageView(Scene scene, out StageView stageView)
        {
            foreach(GameObject gameObject in scene.GetRootGameObjects())
            {
                stageView = gameObject.GetComponent<StageView>();

                if(stageView != null)
                {
                    return true;
                }
            }

            stageView = null;
            return false;
        }
    }
}
