using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UseCaseRepository
    {
        public ISetupStageUseCase SetupStageUseCase { get; }

        public UseCaseRepository(
            ISetupStageUseCase setupStageUseCase
            )
        {
            SetupStageUseCase = setupStageUseCase;
        }
    }
}
