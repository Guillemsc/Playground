namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadEssentialScenesFlowUseCase LoadEssentialScenesFlowUseCase { get; }
        public IShowLoadingScreenFlowUseCase ShowLoadingScreenFlowUseCase { get; }
        public IPlayScenarioFlowUseCase PlayScenarioFlowUseCase { get; }
        public IReplayScenarioFlowUseCase ReplayScenarioFlowUseCase { get; }

        public FlowUseCases(
            ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase,
            IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase,
            IPlayScenarioFlowUseCase playScenarioFlowUseCase,
            IReplayScenarioFlowUseCase replayScenarioFlowUseCase
            )
        {
            LoadEssentialScenesFlowUseCase = loadEssentialScenesFlowUseCase;
            ShowLoadingScreenFlowUseCase = showLoadingScreenFlowUseCase;
            PlayScenarioFlowUseCase = playScenarioFlowUseCase;
            ReplayScenarioFlowUseCase = replayScenarioFlowUseCase;
        }
    }
}
