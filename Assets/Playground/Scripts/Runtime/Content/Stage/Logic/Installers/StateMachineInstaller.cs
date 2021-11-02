using Juce.Core.Events;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.State;
using Playground.Content.Stage.Logic.StateMachine;
using Juce.Core.DI.Container;
using Playground.Content.Stage.Logic.UseCases.SetupStage;
using Playground.Content.Stage.Logic.UseCases.StartStage;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithPointGoal;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithCoin;

namespace Playground.Content.Stage.Logic.Installers
{
    public class StateMachineInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder containerBuilder)
        {
            containerBuilder.Bind<SetupStateMachineAction>()
                .FromFunction((c) => new SetupStateMachineAction(
                    c.Resolve<ISetupStageUseCase>()
                    ));

            containerBuilder.Bind<WaitForStartStateMachineAction>()
                .FromFunction((c) => new WaitForStartStateMachineAction(
                    c.Resolve<IEventReceiver>(),
                    c.Resolve<IStartStageUseCase>()
                    ));

            containerBuilder.Bind<MainStateMachineAction>()
                .FromFunction((c) => new MainStateMachineAction(
                    c.Resolve<IEventReceiver>(),
                    c.Resolve<IShipCollidedWithDeadlyCollisionUseCase>(),
                    c.Resolve<IShipCollidedWithPointGoalUseCase>(),
                    c.Resolve<IShipCollidedWithCoinUseCase>()
                    ));

            containerBuilder.Bind<DisposeStateMachineAction>()
                .FromFunction((c) => new DisposeStateMachineAction(
                    ));

            containerBuilder.Bind<StateMachine<LogicState>>()
                .FromNew()
                .WhenInit(InstallStateMachineStates);
        }

        private void InstallStateMachineStates(IDIResolveContainer c, StateMachine<LogicState> stateMachine)
        {
            stateMachine.RegisterState(LogicState.Setup, c.Resolve<SetupStateMachineAction>());
            stateMachine.RegisterState(LogicState.WaitForStart, c.Resolve<WaitForStartStateMachineAction>());
            stateMachine.RegisterState(LogicState.Main, c.Resolve<MainStateMachineAction>());
            stateMachine.RegisterState(LogicState.Dispose, c.Resolve<DisposeStateMachineAction>());

            stateMachine.RegisterConnection(LogicState.Setup, LogicState.WaitForStart);
            stateMachine.RegisterConnection(LogicState.WaitForStart, LogicState.Main);
            stateMachine.RegisterConnection(LogicState.Main, LogicState.Dispose);
        }
    }
}
