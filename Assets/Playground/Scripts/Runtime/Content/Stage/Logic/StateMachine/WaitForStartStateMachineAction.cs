using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class WaitForStartStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;
        private readonly UseCaseRepository useCaseRepository;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference inputActionReceivedInEvent;

        public WaitForStartStateMachineAction(
            IEventReceiver eventReceiver,
            UseCaseRepository useCaseRepository
            )
        {
            this.eventReceiver = eventReceiver;
            this.useCaseRepository = useCaseRepository;
        }

        public void OnEnter()
        {
            inputActionReceivedInEvent = eventReceiver.Subscribe<InputActionReceivedInEvent>(InputActionReceivedInEvent);
        }

        public void OnExit()
        {
            eventReceiver.Unsubscribe(inputActionReceivedInEvent);
        }

        public void OnRun(IStateMachine<LogicState> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        private void InputActionReceivedInEvent(InputActionReceivedInEvent ev)
        {
            useCaseRepository.StartStageUseCase.Execute();

            stateMachine.SetNextState(LogicState.Main);
        }
    }
}
