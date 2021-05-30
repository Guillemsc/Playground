using Juce.CoreUnity.PointerCallback;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public class StageCompletedUIController
    {
        private readonly StageCompletedUIViewModel viewModel;
        private readonly StageCompletedUIUseCases useCases;

        public StageCompletedUIController(
            StageCompletedUIViewModel viewModel,
            StageCompletedUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.OnPlayAgainClickedEvent.OnExecute += OnPlayAgainClickedEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnPlayAgainClickedEvent.OnExecute -= OnPlayAgainClickedEvent;
        }

        private void OnPlayAgainClickedEvent(StageCompletedUIView stageCompletedUIView, PointerCallbacks pointerCallbacks)
        {
            useCases.PlayAgainUseCase.Execute();
        }
    }
}
