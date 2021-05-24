using Juce.CoreUnity.Scenes;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Contexts;
using Playground.Services;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class StageBootstrapReplayScenarioFlowUseCase : IReplayScenarioFlowUseCase
    {
        public async Task Execute(ILoadingToken loadingToken)
        {
            FlowService flowService = ServicesProvider.GetService<FlowService>();

            ScenesLoader stageScenesLoader = new ScenesLoader(
                StageUIContext.SceneName,
                StageContext.SceneName
                );

            await stageScenesLoader.Unload();

            await flowService.FlowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
}
