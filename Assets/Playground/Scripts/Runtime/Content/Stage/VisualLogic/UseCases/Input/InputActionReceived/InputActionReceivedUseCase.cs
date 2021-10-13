using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.UseCases.ChangeShipDirection;

namespace Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived
{
    public class InputActionReceivedUseCase : IInputActionReceivedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IChangeShipDirectionUseCase changeShipDirectionUseCase;

        public InputActionReceivedUseCase(
            IEventDispatcher eventDispatcher,
            IChangeShipDirectionUseCase changeShipDirectionUseCase
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.changeShipDirectionUseCase = changeShipDirectionUseCase;
        }

        public void Execute()
        {
            eventDispatcher.Dispatch(new InputActionReceivedInEvent());

            changeShipDirectionUseCase.Execute();
        }
    }
}
