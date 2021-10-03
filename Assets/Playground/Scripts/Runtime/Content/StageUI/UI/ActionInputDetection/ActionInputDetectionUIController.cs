using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.ActionInputDetection.UseCases;
using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIController : ISubscribable
    {
        private readonly ActionInputDetectionUIViewModel viewModel;
        private readonly IInputActionReceivedUseCase inputActionReceivedUseCase;

        public ActionInputDetectionUIController(
            ActionInputDetectionUIViewModel viewModel,
            IInputActionReceivedUseCase inputActionReceivedUseCase
            )
        {
            this.viewModel = viewModel;
            this.inputActionReceivedUseCase = inputActionReceivedUseCase;
        }

        public void Subscribe()
        {
            viewModel.OnInputActionEvent.OnExecute += OnInputActionEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnInputActionEvent.OnExecute -= OnInputActionEvent;
        }


        private void OnInputActionEvent(ActionInputDetectionUIView viewModel, PointerEventData pointerEventData)
        {
            inputActionReceivedUseCase.Execute();
        }
    }
}
