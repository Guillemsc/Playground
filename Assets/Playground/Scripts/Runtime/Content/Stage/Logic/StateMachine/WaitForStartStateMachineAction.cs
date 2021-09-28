using Juce.Core.Events;
using Juce.Core.State;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.UseCases;
using Playground.Content.Stage.Logic.UseCases.StartStage;

namespace Playground.Content.Stage.Logic.StateMachine
{
    public class WaitForStartStateMachineAction : IStateMachineStateAction<LogicState>
    {
        private readonly IEventReceiver eventReceiver;
        private readonly IStartStageUseCase startStageUseCase;

        private IStateMachine<LogicState> stateMachine;

        private IEventReference inputActionReceivedInEvent;

        public WaitForStartStateMachineAction(
            IEventReceiver eventReceiver,
            IStartStageUseCase startStageUseCase
            )
        {
            this.eventReceiver = eventReceiver;
            this.startStageUseCase = startStageUseCase;
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
            startStageUseCase.Execute();

            stateMachine.SetNextState(LogicState.Main);
        }
    }
}
