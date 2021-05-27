namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadEssentialScenesFlowUseCase LoadEssentialScenesFlowUseCase { get; }
        public IShowLoadingScreenFlowUseCase ShowLoadingScreenFlowUseCase { get; }
        public ILoadMetaUseCase LoadMetaUseCase { get; }
        public IPlayScenarioFlowUseCase PlayScenarioFlowUseCase { get; }
        public IReplayScenarioFlowUseCase ReplayScenarioFlowUseCase { get; }

        public FlowUseCases(
            ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase,
            IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase,
            ILoadMetaUseCase loadMetaUseCase,
            IPlayScenarioFlowUseCase playScenarioFlowUseCase,
            IReplayScenarioFlowUseCase replayScenarioFlowUseCase
            )
        {
            LoadEssentialScenesFlowUseCase = loadEssentialScenesFlowUseCase;
            ShowLoadingScreenFlowUseCase = showLoadingScreenFlowUseCase;
            LoadMetaUseCase = loadMetaUseCase;
            PlayScenarioFlowUseCase = playScenarioFlowUseCase;
            ReplayScenarioFlowUseCase = replayScenarioFlowUseCase;
        }
    }
}
