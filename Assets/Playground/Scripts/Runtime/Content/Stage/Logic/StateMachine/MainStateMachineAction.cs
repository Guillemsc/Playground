using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithPointGoal;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class MainStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;
        private readonly IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase;
        private readonly IShipCollidedWithPointGoalUseCase shipCollidedWithPointGoalUseCase;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference shipCollidedWithDeadlyCollisionInEvent;
        private IEventReference shipCollidedWithPointGoalInEvent;

        public MainStateMachineAction(
            IEventReceiver eventReceiver,
            IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase,
            IShipCollidedWithPointGoalUseCase shipCollidedWithPointGoalUseCase
            )
        {
            this.eventReceiver = eventReceiver;
            this.shipCollidedWithDeadlyCollisionUseCase = shipCollidedWithDeadlyCollisionUseCase;
            this.shipCollidedWithPointGoalUseCase = shipCollidedWithPointGoalUseCase;
        }

        public void OnEnter()
        {
            shipCollidedWithDeadlyCollisionInEvent = eventReceiver.Subscribe<ShipCollidedWithDeadlyCollisionInEvent>(
                ShipCollidedWithDeadlyCollisionInEvent
                );

            shipCollidedWithPointGoalInEvent = eventReceiver.Subscribe<ShipCollidedWithPointGoalInEvent>(
                ShipCollidedWithPointGoalInEvent
                );
        }

        public void OnExit()
        {
            eventReceiver.Unsubscribe(shipCollidedWithDeadlyCollisionInEvent);
            eventReceiver.Unsubscribe(shipCollidedWithPointGoalInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        private void ShipCollidedWithDeadlyCollisionInEvent(ShipCollidedWithDeadlyCollisionInEvent ev)
        {
            shipCollidedWithDeadlyCollisionUseCase.Execute(ev.ShipInstanceId);
        }

        private void ShipCollidedWithPointGoalInEvent(ShipCollidedWithPointGoalInEvent ev)
        {
            shipCollidedWithPointGoalUseCase.Execute(ev.PointsAmmount);
        }
    }
}
