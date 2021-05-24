using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class MainStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;
        private readonly UseCaseRepository useCaseRepository;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference checkPointCrossedInEvent;
        private IEventReference finishLineCrossedInEvent;

        public MainStateMachineAction(
            IEventReceiver eventReceiver,
            UseCaseRepository useCaseRepository
            )
        {
            this.eventReceiver = eventReceiver;
            this.useCaseRepository = useCaseRepository;
        }

        public void OnEnter()
        {
            checkPointCrossedInEvent = eventReceiver.Subscribe<CheckPointCrossedInEvent>(CheckPointCrossedInEvent);
            finishLineCrossedInEvent = eventReceiver.Subscribe<FinishLineCrossedInEvent>(FinishLineCrossedInEvent);
        }

        public void OnExit()
        {
            eventReceiver.Unsubscribe(checkPointCrossedInEvent);
            eventReceiver.Unsubscribe(finishLineCrossedInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        private void CheckPointCrossedInEvent(CheckPointCrossedInEvent ev)
        {
            useCaseRepository.CheckPointCrossedUseCase.Execute(ev.CheckPointIndex);
        }

        private void FinishLineCrossedInEvent(FinishLineCrossedInEvent ev)
        {
            useCaseRepository.FinishLineCrossedUseCase.Execute();

            stateMachine.SetNextState(LogicState.Dispose);
        }
    }
}
