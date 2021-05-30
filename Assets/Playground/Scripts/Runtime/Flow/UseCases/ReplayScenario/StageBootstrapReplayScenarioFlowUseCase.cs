using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Contexts;
using Playground.Flow.Data;
using Playground.Services;
using System.IO;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class StageBootstrapReplayScenarioFlowUseCase : IReplayScenarioFlowUseCase
    {
        private readonly CurrentStageFlowData currentStageFlowData;

        public StageBootstrapReplayScenarioFlowUseCase(CurrentStageFlowData currentStageFlowData)
        {
            this.currentStageFlowData = currentStageFlowData;
        }

        public async Task Execute(ILoadingToken loadingToken)
        {
            if (currentStageFlowData.StageConfiguration == null)
            {
                UnityEngine.Debug.LogError($"No stage configuration set on {nameof(CurrentStageFlowData)}, " +
                    $"at {nameof(StageBootstrapReplayScenarioFlowUseCase)}");

                return;
            }

            StageConfiguration stageConfiguration = currentStageFlowData.StageConfiguration;

            FlowService flowService = ServicesProvider.GetService<FlowService>();

            string sceneName = Path.GetFileNameWithoutExtension(stageConfiguration.StageSceneReference.ScenePath);

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageUIContext.SceneName,
                StageContext.SceneName,
                sceneName
                );

            await stageScenesLoader.Unload();

            await flowService.FlowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
}
