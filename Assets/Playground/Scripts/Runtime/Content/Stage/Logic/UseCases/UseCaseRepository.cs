using Playground.Content.Stage.Logic.UseCases.TryCreateShip;
using Playground.Content.Stage.Logic.UseCases.SetupStage;
using Playground.Content.Stage.Logic.UseCases.StartStage;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ITryCreateShipUseCase CreateShipUseCase { get; }
        public ISetupStageUseCase SetupStageUseCase { get; }
        public IStartStageUseCase StartStageUseCase { get; }


        public UseCaseRepository(
            ITryCreateShipUseCase createShipUseCase,
            ISetupStageUseCase setupStageUseCase,
            IStartStageUseCase startStageUseCase
            )
        {
            CreateShipUseCase = createShipUseCase;
            SetupStageUseCase = setupStageUseCase;
            StartStageUseCase = startStageUseCase;
        }
    }
}
