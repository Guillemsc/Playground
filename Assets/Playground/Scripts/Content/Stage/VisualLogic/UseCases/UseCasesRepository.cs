namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UseCasesRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }
        public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }
        public ICurrentCheckPointChangedUseCase CurrentCheckPointChangedUseCase { get; }

        public UseCasesRepository(
            ILoadStageUseCase loadStageUseCase,
            ICheckPointCrossedUseCase checkPointCrossedUseCase,
            ICurrentCheckPointChangedUseCase currentCheckPointChangedUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
            CheckPointCrossedUseCase = checkPointCrossedUseCase;
            CurrentCheckPointChangedUseCase = currentCheckPointChangedUseCase;
        }
    }
}
