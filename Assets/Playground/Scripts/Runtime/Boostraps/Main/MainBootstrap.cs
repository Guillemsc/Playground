using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;

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
            //GenerateFlowService();
            //GenerateSharedService();

            //FlowService flowService = ServicesProvider.GetService<FlowService>();
            //FlowUseCases flowUseCases = flowService.FlowUseCases;

            //await flowUseCases.LoadEssentialScenesFlowUseCase.Execute();

            //flowUseCases.LoadBaseCheatsFlowUseCase.Execute();

            //await flowUseCases.LoadLocalizationDataFlowUseCase.Execute();

            //ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: true);

            //await flowUseCases.LoadUserDataFlowUseCase.Execute();

            //await flowUseCases.LoadAdsScenesFlowUseCase.Execute();

            //await flowUseCases.LoadMetaFlowUseCase.Execute(loadingToken);
        }

        private void GenerateFlowService()
        {
            //CurrentStageFlowData currentStageFlowData = new CurrentStageFlowData();

            //ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase = new LoadEssentialScenesFlowUseCase();
            //ILoadBaseCheatsFlowUseCase loadBaseCheatsFlowUseCase = new LoadBaseCheatsFlowUseCase();
            //ISetStageCheatsActiveFlowUseCase setStageCheatsActiveFlowUseCase = new SetStageCheatsActiveFlowUseCase();
            //ILoadLocalizationDataFlowUseCase loadLocalizationDataFlowUseCase = new LoadLocalizationDataFlowUseCase();
            //IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase = new ShowLoadingScreenFlowUseCase();
            //ILoadUserDataFlowUseCase loadUserDataFlowUseCase = new LoadUserDataFlowUseCase();
            //ILoadAdsScenesFlowUseCase loadAdsScenesFlowUseCase = new LoadAdsScenesFlowUseCase();
            //ILoadMetaFlowUseCase loadMetaFlowUseCase = new LoadMetaFlowUseCase();
            //IUnloadMetaFlowUseCase unloadMetaFlowUseCase = new UnloadMetaFlowUseCase();
            //ISetCurrentStageFlowUseCase setCurrentStageFlowUseCase = new SetCurrentStageFlowUseCase(currentStageFlowData);
            //IPlayScenarioFlowUseCase playScenarioFlowUseCase = new MainBootstrapPlayScenarioFlowUseCase(
            //    setStageCheatsActiveFlowUseCase,
            //    currentStageFlowData
            //    );
            //IReplayScenarioFlowUseCase replayScenarioFlowUseCase = new ReplayScenarioFlowUseCase(
            //    setStageCheatsActiveFlowUseCase,
            //    currentStageFlowData
            //    ); // Todo update
            //IBackToMetaFromStageFlowUseCase backToMetaFromStageFlowUseCase = new BackToMetaFromStageFlowUseCase(
            //    setStageCheatsActiveFlowUseCase,
            //    currentStageFlowData
            //    );

            //FlowUseCases flowUseCases = new FlowUseCases(
            //    loadEssentialScenesFlowUseCase,
            //    loadBaseCheatsFlowUseCase,
            //    setStageCheatsActiveFlowUseCase,
            //    loadLocalizationDataFlowUseCase,
            //    showLoadingScreenFlowUseCase,
            //    loadUserDataFlowUseCase,
            //    loadAdsScenesFlowUseCase,
            //    loadMetaFlowUseCase,
            //    unloadMetaFlowUseCase,
            //    setCurrentStageFlowUseCase,
            //    playScenarioFlowUseCase,
            //    replayScenarioFlowUseCase,
            //    backToMetaFromStageFlowUseCase
            //    );

            //FlowService flowService = new FlowService(flowUseCases);
            //ServicesProvider.Register(flowService);
        }
    }
}
