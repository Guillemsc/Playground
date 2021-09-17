using Playground.Content.StageUI.UI.ActionInputDetection.UseCases;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIUseCases
    {
        public IInputActionReceivedUseCase InputActionReceivedUseCase { get; }

        public ActionInputDetectionUIUseCases(
            IInputActionReceivedUseCase inputActionReceivedUseCase
            )
        {
            InputActionReceivedUseCase = inputActionReceivedUseCase;
        }
    }
}
