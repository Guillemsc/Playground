using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithDeadlyCollision;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class MainStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;
        private readonly IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference shipCollidedWithDeadlyCollisionInEvent;

        public MainStateMachineAction(
            IEventReceiver eventReceiver,
            IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase
            )
        {
            this.eventReceiver = eventReceiver;
            this.shipCollidedWithDeadlyCollisionUseCase = shipCollidedWithDeadlyCollisionUseCase;
        }

        public void OnEnter()
        {
            shipCollidedWithDeadlyCollisionInEvent = eventReceiver.Subscribe<ShipCollidedWithDeadlyCollisionInEvent>(
                ShipCollidedWithDeadlyCollisionInEvent
                );
        }

        public void OnExit()
        {
            eventReceiver.Unsubscribe(shipCollidedWithDeadlyCollisionInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        private void ShipCollidedWithDeadlyCollisionInEvent(ShipCollidedWithDeadlyCollisionInEvent ev)
        {
            shipCollidedWithDeadlyCollisionUseCase.Execute(ev.ShipInstanceId);
        }

        //private void CheckPointCrossedInEvent(CheckPointCrossedInEvent ev)
        //{
        //    useCaseRepository.CheckPointCrossedUseCase.Execute(ev.CheckPointIndex);
        //}

        //private void FinishLineCrossedInEvent(FinishLineCrossedInEvent ev)
        //{
        //    useCaseRepository.FinishLineCrossedUseCase.Execute();

        //    bool completed = useCaseRepository.IsStageCompletedUseCase.Execute();

        //    if(!completed)
        //    {
        //        return;
        //    }

        //    stateMachine.SetNextState(LogicState.Dispose);
        //}
    }
}
