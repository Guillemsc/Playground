namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ILoadStageUseCase LoadStageUseCase { get; }

        public UseCaseRepository(
            ILoadStageUseCase loadStageUseCase
            )
        {
            LoadStageUseCase = loadStageUseCase;
        }
    }
}
