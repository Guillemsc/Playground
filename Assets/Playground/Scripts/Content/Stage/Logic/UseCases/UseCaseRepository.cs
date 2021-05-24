namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }
        public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }
        public IFinishLineCrossedUseCase FinishLineCrossedUseCase { get; }

        public UseCaseRepository(
            ILoadStageUseCase loadStageUseCase,
            ICheckPointCrossedUseCase checkPointCrossedUseCase,
            IFinishLineCrossedUseCase finishLineCrossedUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
            CheckPointCrossedUseCase = checkPointCrossedUseCase;
            FinishLineCrossedUseCase = finishLineCrossedUseCase;
        }
    }
}
