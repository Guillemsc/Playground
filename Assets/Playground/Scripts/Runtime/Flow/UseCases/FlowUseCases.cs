namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadEssentialScenesFlowUseCase LoadEssentialScenesFlowUseCase { get; }
        public ILoadLocalizationDataFlowUseCase LoadLocalizationDataFlowUseCase { get; }
        public IShowLoadingScreenFlowUseCase ShowLoadingScreenFlowUseCase { get; }
        public ILoadUserDataFlowUseCase LoadUserDataFlowUseCase { get; }
        public ILoadAdsScenesFlowUseCase LoadAdsScenesFlowUseCase { get; }
        public ILoadMetaFlowUseCase LoadMetaFlowUseCase { get; }
        public IUnloadMetaFlowUseCase UnloadMetaFlowUseCase { get; }
        public ISetCurrentStageFlowUseCase SetCurrentStageFlowUseCase { get; }
        public IPlayScenarioFlowUseCase PlayScenarioFlowUseCase { get; }
        public IReplayScenarioFlowUseCase ReplayScenarioFlowUseCase { get; }
        public IBackToMetaFromStageFlowUseCase BackToMetaFromStageFlowUseCase { get; }

        public FlowUseCases(
            ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase,
            ILoadLocalizationDataFlowUseCase loadLocalizationDataFlowUseCase,
            IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase,
            ILoadUserDataFlowUseCase loadUserDataFlowUseCase,
            ILoadAdsScenesFlowUseCase loadAdsScenesFlowUseCase,
            ILoadMetaFlowUseCase loadMetaFlowUseCase,
            IUnloadMetaFlowUseCase unloadMetaFlowUseCase,
            ISetCurrentStageFlowUseCase setCurrentStageFlowUseCase,
            IPlayScenarioFlowUseCase playScenarioFlowUseCase,
            IReplayScenarioFlowUseCase replayScenarioFlowUseCase,
            IBackToMetaFromStageFlowUseCase backToMetaFromStageFlowUseCase
            )
        {
            LoadEssentialScenesFlowUseCase = loadEssentialScenesFlowUseCase;
            LoadLocalizationDataFlowUseCase = loadLocalizationDataFlowUseCase;
            ShowLoadingScreenFlowUseCase = showLoadingScreenFlowUseCase;
            LoadUserDataFlowUseCase = loadUserDataFlowUseCase;
            LoadAdsScenesFlowUseCase = loadAdsScenesFlowUseCase;
            LoadMetaFlowUseCase = loadMetaFlowUseCase;
            UnloadMetaFlowUseCase = unloadMetaFlowUseCase;
            SetCurrentStageFlowUseCase = setCurrentStageFlowUseCase;
            PlayScenarioFlowUseCase = playScenarioFlowUseCase;
            ReplayScenarioFlowUseCase = replayScenarioFlowUseCase;
            BackToMetaFromStageFlowUseCase = backToMetaFromStageFlowUseCase;
        }
    }
}
