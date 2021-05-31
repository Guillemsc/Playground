namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UseCasesRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }
        public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }
        public IFinishLineCrossedUseCase FinishLineCrossedUseCase { get; }
        public ICurrentCheckPointChangedUseCase CurrentCheckPointChangedUseCase { get; }
        public INextCheckPointChangedUseCase NextCheckPointChangedUseCase { get; }
        public IStageFinishedUseCase StageFinishedUseCase { get; }
        public IRestartStageUseCase RestartStageUseCase { get; }
        public IExitStageUseCase ExitStageUseCase { get; }

        public UseCasesRepository(
            ILoadStageUseCase loadStageUseCase,
            ICheckPointCrossedUseCase checkPointCrossedUseCase,
            IFinishLineCrossedUseCase finishLineCrossedUseCase,
            ICurrentCheckPointChangedUseCase currentCheckPointChangedUseCase,
            INextCheckPointChangedUseCase nextCheckPointChangedUseCase,
            IStageFinishedUseCase stageFinishedUseCase,
            IRestartStageUseCase restartStageUseCase,
            IExitStageUseCase exitStageUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
            CheckPointCrossedUseCase = checkPointCrossedUseCase;
            FinishLineCrossedUseCase = finishLineCrossedUseCase;
            CurrentCheckPointChangedUseCase = currentCheckPointChangedUseCase;
            NextCheckPointChangedUseCase = nextCheckPointChangedUseCase;
            StageFinishedUseCase = stageFinishedUseCase;
            RestartStageUseCase = restartStageUseCase;
            ExitStageUseCase = exitStageUseCase;
        }
    }
}
