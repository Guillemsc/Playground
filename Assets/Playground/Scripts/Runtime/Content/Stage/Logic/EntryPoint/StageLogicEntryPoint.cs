using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Logic.StateMachine;
using Juce.Core.DI.Builder;
using Playground.Content.Stage.Logic.Installers;
using Juce.Core.DI.Container;
using Playground.Cheats;

namespace Playground.Content.Stage.Logic.EntryPoint
{
    public class StageLogicEntryPoint
    {
        private StateMachine<LogicState> stateMachine;

        public StageLogicCheats StageLogicCheats { get; }

        public StageLogicEntryPoint(
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            StageLogicSetup logicStageSetup
            )
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind<IEventDispatcher>().FromInstance(eventDispatcher);
            containerBuilder.Bind<IEventReceiver>().FromInstance(eventReceiver);
            containerBuilder.Bind<StageLogicSetup>().FromInstance(logicStageSetup);

            containerBuilder.Bind(new UseCasesInstaller());
            containerBuilder.Bind(new StateMachineInstaller());
            containerBuilder.Bind(new CheatsInstaller());

            IDIContainer container = containerBuilder.Build();

            StageLogicCheats = container.Resolve<StageLogicCheats>();

            stateMachine = container.Resolve<StateMachine<LogicState>>();
        }

        public void Execute()
        {
            stateMachine.Start(LogicState.Setup);
        }
    }
}
