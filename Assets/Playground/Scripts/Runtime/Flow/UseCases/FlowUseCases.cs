﻿namespace Playground.Flow.UseCases
{
    public class FlowUseCases
    {
        public ILoadEssentialScenesFlowUseCase LoadEssentialScenesFlowUseCase { get; }
        public IShowLoadingScreenFlowUseCase ShowLoadingScreenFlowUseCase { get; }
        public ILoadAdsScenesFlowUseCase LoadAdsScenesFlowUseCase { get; }
        public ILoadMetaFlowUseCase LoadMetaFlowUseCase { get; }
        public IUnloadMetaFlowUseCase UnloadMetaFlowUseCase { get; }
        public ISetCurrentStageFlowUseCase SetCurrentStageFlowUseCase { get; }
        public IPlayScenarioFlowUseCase PlayScenarioFlowUseCase { get; }
        public IReplayScenarioFlowUseCase ReplayScenarioFlowUseCase { get; }
        public IBackToMetaFromStageFlowUseCase BackToMetaFromStageFlowUseCase { get; }

        public FlowUseCases(
            ILoadEssentialScenesFlowUseCase loadEssentialScenesFlowUseCase,
            IShowLoadingScreenFlowUseCase showLoadingScreenFlowUseCase,
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
            ShowLoadingScreenFlowUseCase = showLoadingScreenFlowUseCase;
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
