namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases
{
    public class InputActionReceivedUseCase : IInputActionReceivedUseCase
    {
        private readonly ActionInputDetectionUIEvents actionInputDetectionUIEvents;

        public InputActionReceivedUseCase(
            ActionInputDetectionUIEvents actionInputDetectionUIEvents
            )
        {
            this.actionInputDetectionUIEvents = actionInputDetectionUIEvents;
        }

        public void Execute()
        {
            actionInputDetectionUIEvents.InputActionReceived?.Invoke();
        }
    }
}
