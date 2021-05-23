namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UseCasesRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }
        public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }

        public UseCasesRepository(
            ILoadStageUseCase loadStageUseCase,
            ICheckPointCrossedUseCase checkPointCrossedUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
            CheckPointCrossedUseCase = checkPointCrossedUseCase;
        }
    }
}
