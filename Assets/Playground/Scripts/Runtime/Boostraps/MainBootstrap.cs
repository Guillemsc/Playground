using System.Threading.Tasks;
using UnityEngine;
using Playground.Flow.UseCases;
using Playground.Services;
using Juce.CoreUnity.Service;
using Playground.Flow.UseCases.LoadServicesContext;
using Playground.Flow.UseCases.LoadBaseCheats;
using Playground.Flow.UseCases.LoadLocalizationData;
using Playground.Flow.UseCases.LoadLoadingScreenContext;
using Playground.Flow.UseCases.ShowLoadingScreen;
using Playground.Content.LoadingScreen.UI;
using Playground.Flow.UseCases.LoadStageContext;
using Juce.Core.Loading;
using Playground.Flow.UseCases.LoadStage;
using Playground.Content.Stage.Setup;
using Playground.Flow.UseCases.LoadCamerasContext;

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
            GenerateFlowService();

            FlowService flowService = ServicesProvider.GetService<FlowService>();
            FlowUseCases flowUseCases = flowService.FlowUseCases;

            await flowUseCases.LoadServicesContextUseCase.Execute();
            await flowUseCases.LoadLoadingScreenContextUseCase.Execute();
            await flowUseCases.LoadCamerasContextUseCase.Execute();

            ILoadingToken loadingToken = await flowUseCases.ShowLoadingScreenUseCase.Execute();

            flowUseCases.LoadBaseCheatsUseCase.Execute();

            await flowUseCases.LoadLocalizationDataUseCase.Execute();

            await flowUseCases.LoadStageContextUseCase.Execute();

            await flowUseCases.LoadStageUseCase.Execute(
                new StageSetup(
                    new ShipSetup(string.Empty)
                ));

            loadingToken.Complete();

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

            ILoadServicesContextUseCase loadServicesContextUseCase = new LoadServicesContextUseCase();

            ILoadCamerasContextUseCase loadCamerasContextUseCase = new LoadCamerasContextUseCase();

            ILoadLoadingScreenContextUseCase loadLoadingScreenContextUseCase = new LoadLoadingScreenContextUseCase();

            ILoadStageContextUseCase loadStageContextUseCase = new LoadStageContextUseCase();
            IShowLoadingScreenUseCase showLoadingScreenUseCase = new ShowLoadingScreenUseCase();

            ILoadBaseCheatsUseCase loadBaseCheatsUseCase = new LoadBaseCheatsUseCase();

            ILoadLocalizationDataUseCase loadLocalizationDataUseCase = new LoadLocalizationDataUseCase();

            ILoadStageUseCase loadStageUseCase = new LoadStageUseCase();

            FlowUseCases flowUseCases = new FlowUseCases(
                loadServicesContextUseCase,
                loadCamerasContextUseCase,
                loadLoadingScreenContextUseCase,
                loadStageContextUseCase,
                showLoadingScreenUseCase,
                loadBaseCheatsUseCase,
                loadLocalizationDataUseCase,
                loadStageUseCase
                );

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

            FlowService flowService = new FlowService(flowUseCases);
            ServicesProvider.Register(flowService);
        }
    }
}
