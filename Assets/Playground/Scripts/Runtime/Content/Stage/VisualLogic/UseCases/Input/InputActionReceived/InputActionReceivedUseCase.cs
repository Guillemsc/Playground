using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;

namespace Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived
{
    public class InputActionReceivedUseCase : IInputActionReceivedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public InputActionReceivedUseCase(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute()
        {
            eventDispatcher.Dispatch(new InputActionReceivedInEvent());
        }
    }
}
