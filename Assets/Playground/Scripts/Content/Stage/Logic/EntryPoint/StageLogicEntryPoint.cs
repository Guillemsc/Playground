using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.CheckPoints;
using Playground.Content.Stage.Logic.State;
using Playground.Content.Stage.Logic.StateMachine;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.EntryPoint
{
    public class StageLogicEntryPoint
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;
        private readonly CheckPointRepository checkPointRepository;

        private readonly UseCaseRepository useCaseRepository;

        public StageLogicEntryPoint(
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            CheckPointRepository checkPointRepository
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;
            this.checkPointRepository = checkPointRepository;

            CheckPointsState checkPointState = new CheckPointsState();

            useCaseRepository = new UseCaseRepository(
                new LoadStageUseCase(
                    eventDispatcher
                    ),

                new CheckPointCrossedUseCase(
                    eventDispatcher,
                    checkPointRepository,
                    checkPointState
                    ),

                new FinishLineCrossedUseCase(
                    eventDispatcher,
                    checkPointState
                    )
                );
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
