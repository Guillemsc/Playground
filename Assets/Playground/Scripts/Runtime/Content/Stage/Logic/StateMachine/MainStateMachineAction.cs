using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class MainStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference carAcceleratesOrBrakesInEvent;
        private IEventReference checkPointCrossedInEvent;
        private IEventReference finishLineCrossedInEvent;

        public MainStateMachineAction(
            IEventReceiver eventReceiver
            )
        {
            this.eventReceiver = eventReceiver;
        }

        public void OnEnter()
        {
            //carAcceleratesOrBrakesInEvent = eventReceiver.Subscribe<CarAcceleratesOrBrakesInEvent>(CarAcceleratesOrBrakesInEvent);
            //checkPointCrossedInEvent = eventReceiver.Subscribe<CheckPointCrossedInEvent>(CheckPointCrossedInEvent);
            //finishLineCrossedInEvent = eventReceiver.Subscribe<FinishLineCrossedInEvent>(FinishLineCrossedInEvent);
        }

        public void OnExit()
        {
            //eventReceiver.Unsubscribe(carAcceleratesOrBrakesInEvent);
            //eventReceiver.Unsubscribe(checkPointCrossedInEvent);
            //eventReceiver.Unsubscribe(finishLineCrossedInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        //private void CarAcceleratesOrBrakesInEvent(CarAcceleratesOrBrakesInEvent ev)
        //{
        //    useCaseRepository.StartStageUseCase.Execute();
        //}

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
