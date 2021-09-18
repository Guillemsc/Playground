using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Id;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Logic.StateMachine;
using Playground.Content.Stage.Logic.UseCases;
using Playground.Content.Stage.Logic.UseCases.TryCreateShip;
using Playground.Content.Stage.Logic.UseCases.SetupStage;
using Playground.Content.Stage.Logic.UseCases.StartStage;
using Playground.Content.Stage.Logic.State;
using Juce.Core.Repositories;

namespace Playground.Content.Stage.Logic.EntryPoint
{
    public class StageLogicEntryPoint
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;

        private UseCaseRepository useCaseRepository;

        public StageLogicEntryPoint(
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            LogicStageSetup logicStageSetup
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;

            IIdGenerator idGenerator = new IncrementalIdGenerator();

            IFactory<LogicShipSetup, ShipEntity> shipEntityFactory = new ShipEntityFactory(idGenerator);
            IKeyValueRepository<int, ShipEntity> shipEntityRepository = new SimpleKeyValueRepository<int, ShipEntity>();

            StageState stageState = new StageState();

            ITryCreateShipUseCase createShipUseCase = new TryCreateShipUseCase(
                shipEntityFactory,
                shipEntityRepository
                );

            ISetupStageUseCase setupStageUseCase = new SetupStageUseCase(
                eventDispatcher,
                logicStageSetup,
                stageState,
                createShipUseCase
                );

            IStartStageUseCase startStageUseCase = new StartStageUseCase(
                eventDispatcher,
                stageState,
                shipEntityRepository
                );

            useCaseRepository = new UseCaseRepository(
                createShipUseCase,
                setupStageUseCase,
                startStageUseCase
                );
        }

        public void Execute()
        {
            StateMachine<LogicState> stateMachine = new StateMachine<LogicState>();

            stateMachine.RegisterState(LogicState.Setup, new SetupStateMachineAction(
                useCaseRepository
                ));

            stateMachine.RegisterState(LogicState.WaitForStart, new WaitForStartStateMachineAction(
                eventReceiver,
                useCaseRepository
                ));

            stateMachine.RegisterState(LogicState.Main, new MainStateMachineAction(
                eventReceiver,
                useCaseRepository
                ));

            stateMachine.RegisterState(LogicState.Dispose, new DisposeStateMachineAction(
                useCaseRepository
                ));

            stateMachine.RegisterConnection(LogicState.Setup, LogicState.WaitForStart);
            stateMachine.RegisterConnection(LogicState.WaitForStart, LogicState.Main);
            stateMachine.RegisterConnection(LogicState.Main, LogicState.Dispose);

            stateMachine.Start(LogicState.Setup);
        }
    }
}
