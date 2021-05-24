using Playground.Content.Stage.Configuration;
using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;

namespace Playground.Boostraps
{
    public class StageBootstrap : MonoBehaviour
    {
        [SerializeField] private StageConfiguration stageConfiguration = default;

        private void Awake()
        {
            Run().RunAsync();
        }

        private async Task Run()
        {
            FlowUseCases flowUseCases = new FlowUseCases(
                new LoadEssentialScenesFlowUseCase(),
                new ShowLoadingScreenFlowUseCase(),
                new StageBootstrapPlayScenarioFlowUseCase(stageConfiguration),
                new StageBootstrapReplayScenarioFlowUseCase()
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);

            await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }    
    }
}
