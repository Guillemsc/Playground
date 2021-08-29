using Playground.Content.Stage.Logic.UseCases.CreateShip;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class UseCaseRepository
    {
        public ICreateShipUseCase CreateShipUseCase { get; }

        //public ILoadStageUseCase LoadStageUseCase { get; }
        //public IStartStageUseCase StartStageUseCase { get; }
        //public ICheckPointCrossedUseCase CheckPointCrossedUseCase { get; }
        //public IFinishLineCrossedUseCase FinishLineCrossedUseCase { get; }
        //public IIsStageCompletedUseCase IsStageCompletedUseCase { get; }

        public UseCaseRepository(
            ICreateShipUseCase createShipUseCase
            )
        {
            CreateShipUseCase = createShipUseCase;
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
