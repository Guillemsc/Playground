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

        private IEventReference checkPointCrossedInEvent;

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
        }

        public void OnExit()
        {
            eventReceiver.Unsubscribe(checkPointCrossedInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {

        }

        private void CheckPointCrossedInEvent(CheckPointCrossedInEvent ev)
        {
            useCaseRepository.CheckPointCrossedUseCase.Execute(ev.CheckPointIndex);
        }
    }
}
