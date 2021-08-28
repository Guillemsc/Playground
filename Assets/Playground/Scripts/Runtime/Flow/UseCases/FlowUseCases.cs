using Playground.Flow.UseCases.LoadBaseCheats;
using Playground.Flow.UseCases.LoadLoadingScreenContext;
using Playground.Flow.UseCases.LoadLocalizationData;
using Playground.Flow.UseCases.LoadServicesContext;
using Playground.Flow.UseCases.ShowLoadingScreen;

namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadServicesContextUseCase LoadServicesContextUseCase { get; }
        public ILoadLoadingScreenContextUseCase LoadLoadingScreenContextUseCase { get; }
        public ILoadBaseCheatsUseCase LoadBaseCheatsUseCase { get; }
        public ILoadLocalizationDataUseCase LoadLocalizationDataUseCase { get; }
        public IShowLoadingScreenUseCase ShowLoadingScreenUseCase { get; }

        //public ILoadBaseCheatsFlowUseCase LoadBaseCheatsFlowUseCase { get; }
        //public ISetStageCheatsActiveFlowUseCase SetStageCheatsActiveFlowUseCase { get; }
        //public ILoadLocalizationDataFlowUseCase LoadLocalizationDataFlowUseCase { get; }
        //public IShowLoadingScreenFlowUseCase ShowLoadingScreenFlowUseCase { get; }
        //public ILoadUserDataFlowUseCase LoadUserDataFlowUseCase { get; }
        //public ILoadAdsScenesFlowUseCase LoadAdsScenesFlowUseCase { get; }
        //public ILoadMetaFlowUseCase LoadMetaFlowUseCase { get; }
        //public IUnloadMetaFlowUseCase UnloadMetaFlowUseCase { get; }
        //public ISetCurrentStageFlowUseCase SetCurrentStageFlowUseCase { get; }
        //public IPlayScenarioFlowUseCase PlayScenarioFlowUseCase { get; }
        //public IReplayScenarioFlowUseCase ReplayScenarioFlowUseCase { get; }
        //public IBackToMetaFromStageFlowUseCase BackToMetaFromStageFlowUseCase { get; }

        public FlowUseCases(
            ILoadServicesContextUseCase loadServicesContextUseCase,
            ILoadLoadingScreenContextUseCase loadLoadingScreenContextUseCase,
            ILoadBaseCheatsUseCase loadBaseCheatsUseCase,
            ILoadLocalizationDataUseCase loadLocalizationDataUseCase,
            IShowLoadingScreenUseCase showLoadingScreenUseCase
            )
        {
            LoadServicesContextUseCase = loadServicesContextUseCase;
            LoadLoadingScreenContextUseCase = loadLoadingScreenContextUseCase;
            LoadBaseCheatsUseCase = loadBaseCheatsUseCase;
            LoadLocalizationDataUseCase = loadLocalizationDataUseCase;
            ShowLoadingScreenUseCase = showLoadingScreenUseCase;
        }

        //public FlowUseCases(
        //    ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase,
        //    ILoadBaseCheatsFlowUseCase loadBaseCheatsFlowUseCase,
        //    ISetStageCheatsActiveFlowUseCase setStageCheatsActiveFlowUseCase,
        //    ILoadLocalizationDataFlowUseCase loadLocalizationDataFlowUseCase,
        //    IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase,
        //    ILoadUserDataFlowUseCase loadUserDataFlowUseCase,
        //    ILoadAdsScenesFlowUseCase loadAdsScenesFlowUseCase,
        //    ILoadMetaFlowUseCase loadMetaFlowUseCase,
        //    IUnloadMetaFlowUseCase unloadMetaFlowUseCase,
        //    ISetCurrentStageFlowUseCase setCurrentStageFlowUseCase,
        //    IPlayScenarioFlowUseCase playScenarioFlowUseCase,
        //    IReplayScenarioFlowUseCase replayScenarioFlowUseCase,
        //    IBackToMetaFromStageFlowUseCase backToMetaFromStageFlowUseCase
        //    )
        //{
        //    LoadEssentialScenesFlowUseCase = loadEssentialScenesFlowUseCase;
        //    LoadBaseCheatsFlowUseCase = loadBaseCheatsFlowUseCase;
        //    SetStageCheatsActiveFlowUseCase = setStageCheatsActiveFlowUseCase;
        //    LoadLocalizationDataFlowUseCase = loadLocalizationDataFlowUseCase;
        //    ShowLoadingScreenFlowUseCase = showLoadingScreenFlowUseCase;
        //    LoadUserDataFlowUseCase = loadUserDataFlowUseCase;
        //    LoadAdsScenesFlowUseCase = loadAdsScenesFlowUseCase;
        //    LoadMetaFlowUseCase = loadMetaFlowUseCase;
        //    UnloadMetaFlowUseCase = unloadMetaFlowUseCase;
        //    SetCurrentStageFlowUseCase = setCurrentStageFlowUseCase;
        //    PlayScenarioFlowUseCase = playScenarioFlowUseCase;
        //    ReplayScenarioFlowUseCase = replayScenarioFlowUseCase;
        //    BackToMetaFromStageFlowUseCase = backToMetaFromStageFlowUseCase;
        //}
    }
}
