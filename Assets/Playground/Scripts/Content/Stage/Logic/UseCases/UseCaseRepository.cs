namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }
        public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }

        public UseCaseRepository(
            ILoadStageUseCase loadStageUseCase,
            ICheckPointCrossedUseCase checkPointCrossedUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
            CheckPointCrossedUseCase = checkPointCrossedUseCase;
        }
    }
}
