using Playground.Content.Stage.Logic.UseCases.TryCreateShip;
using Playground.Content.Stage.Logic.UseCases.SetupStage;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ITryCreateShipUseCase CreateShipUseCase { get; }
        public ISetupStageUseCase SetupStageUseCase { get; }

        //public ILoadStageUseCase LoadStageUseCase { get; }
        //public IStartStageUseCase StartStageUseCase { get; }
        //public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }
        //public IFinishLineCrossedUseCase FinishLineCrossedUseCase { get; }
        //public IIsStageCompletedUseCase IsStageCompletedUseCase { get; }

        public UseCaseRepository(
            ITryCreateShipUseCase createShipUseCase,
            ISetupStageUseCase setupStageUseCase
            )
        {
            CreateShipUseCase = createShipUseCase;
            SetupStageUseCase = setupStageUseCase;
        }

        //public UseCaseRepository(
        //    ILoadStageUseCase loadStageUseCase,
        //    IStartStageUseCase startStageUseCase,
        //    ICheckPointCrossedUseCase checkPointCrossedUseCase,
        //    IFinishLineCrossedUseCase finishLineCrossedUseCase,
        //    IIsStageCompletedUseCase isStageCompletedUseCase
        //    )
        //{
        //    LoadStageUseCase = loadStageUseCase;
        //    StartStageUseCase = startStageUseCase;
        //    CheckPointCrossedUseCase = checkPointCrossedUseCase;
        //    FinishLineCrossedUseCase = finishLineCrossedUseCase;
        //    IsStageCompletedUseCase = isStageCompletedUseCase;
        //}
    }
}
