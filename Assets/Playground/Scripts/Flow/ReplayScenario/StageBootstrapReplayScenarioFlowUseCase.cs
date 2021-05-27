using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Contexts;
using Playground.Services;
using System.IO;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class StageBootstrapReplayScenarioFlowUseCase : IReplayScenarioFlowUseCase
    {
        private readonly StageConfiguration stageConfiguration;

        public StageBootstrapReplayScenarioFlowUseCase(StageConfiguration stageConfiguration)
        {
            this.stageConfiguration = stageConfiguration;
        }

        public async Task Execute(ILoadingToken loadingToken)
        {
            FlowService flowService = ServicesProvider.GetService<FlowService>();

            string sceneName = Path.GetFileNameWithoutExtension(stageConfiguration.StageScene.ScenePath);

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
