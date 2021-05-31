using Playground.Content.Stage.Configuration;
using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Flow.Data;

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
            if(stageConfiguration.StageSceneReference == null)
            {
                UnityEngine.Debug.LogError($"Stage scene is not referenced, at {nameof(StageBootstrap)}");
                return;
            }

            CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            FlowUseCases flowUseCases = new FlowUseCases(
                new LoadEssentialScenesFlowUseCase(),
                new ShowLoadingScreenFlowUseCase(),
                new NopLoadMetaFlowUseCase(),
                new NopUnloadMetaFlowUseCase(),
                new SetCurrentStageFlowUseCase(currentStageFlowData),
                new StageBootstrapPlayScenarioFlowUseCase(currentStageFlowData),
                new StageBootstrapReplayScenarioFlowUseCase(currentStageFlowData),
                new NopBackToMetaFromStageFlowUseCase()
                );

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);

            await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            flowUseCases.SetCurrentStageFlowUseCase.Execute(stageConfiguration);

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            await flowUseCases.PlayScenarioFlowUseCase.Execute(loadingToken);
        }    
    }
}
