using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Flow.Data;

namespace Playground.Boostraps
{
    public class MainBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            FlowUseCases flowUseCases = new FlowUseCases(
                new LoadEssentialScenesFlowUseCase(),
                new ShowLoadingScreenFlowUseCase(),
                new LoadMetaFlowUseCase(),
                new UnloadMetaFlowUseCase(),
                new SetCurrentStageFlowUseCase(currentStageFlowData),
                new MainBootstrapPlayScenarioFlowUseCase(currentStageFlowData),
                new StageBootstrapReplayScenarioFlowUseCase(currentStageFlowData),
                new BackToMetaFromStageFlowUseCase(currentStageFlowData)
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);

            await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.LoadMetaFlowUseCase.Execute(loadingToken);
        }
    }
}
