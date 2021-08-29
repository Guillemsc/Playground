using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.StateMachine;
using Playground.Content.Stage.Logic.UseCases;
using Playground.Content.Stage.Logic.UseCases.CreateShip;

namespace Playground.Content.Stage.Logic.EntryPoint
{
    public class StageLogicEntryPoint
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;

        private UseCaseRepository useCaseRepository;

        public StageLogicEntryPoint(
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;

            //StageState stageState = new StageState();
            //CheckPointsState checkPointState = new CheckPointsState();

            ICreateShipUseCase createShipUseCase = new CreateShipUseCase(
                );

            useCaseRepository = new UseCaseRepository(
                createShipUseCase
                );

            //useCaseRepository = new UseCaseRepository(
            //    new LoadStageUseCase(
            //        eventDispatcher
            //        ),

            //    new StartStageUseCase(
            //        eventDispatcher,
            //        stageState
            //        ),

            //    new CheckPointCrossedUseCase(
            //        eventDispatcher,
            //        checkPointRepository,
            //        checkPointState
            //        ),

            //    new FinishLineCrossedUseCase(
            //        eventDispatcher,
            //        stageState,
            //        checkPointState
            //        ),

            //    new IsStageCompletedUseCase(
            //        stageState
            //        )
            //    );
        }

        public void Execute()
        {
            StateMachine<LogicState> stateMachine = new StateMachine<LogicState>();

            stateMachine.RegisterState(LogicState.Setup, new SetupStateMachineAction(
                useCaseRepository
                ));

            stateMachine.RegisterState(LogicState.Main, new MainStateMachineAction(
                eventReceiver,
                useCaseRepository
                ));

            stateMachine.RegisterState(LogicState.Dispose, new DisposeStateMachineAction(
                useCaseRepository
                ));

            stateMachine.RegisterConnection(LogicState.Setup, LogicState.Main);
            stateMachine.RegisterConnection(LogicState.Main, LogicState.Dispose);

            stateMachine.Start(LogicState.Setup);
        }
    }
}
