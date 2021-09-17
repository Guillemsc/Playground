using UnityEngine.EventSystems;

namespace Playground.Content.StageUI.UI.ActionInputDetection
{
    public class ActionInputDetectionUIController
    {
        private readonly ActionInputDetectionUIViewModel viewModel;
        private readonly ActionInputDetectionUIUseCases useCases;

        public ActionInputDetectionUIController(
            ActionInputDetectionUIViewModel viewModel,
            ActionInputDetectionUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
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
            useCases.InputActionReceivedUseCase.Execute();
        }
    }
}
