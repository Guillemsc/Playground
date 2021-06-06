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
            viewModel.PlayAgainEvent.OnExecute += OnPlayAgainClickedEvent;
            viewModel.StarsVariable.OnChange += OnStarsVariableChanged;
        }

        public void Unsubscribe()
        {
            viewModel.PlayAgainEvent.OnExecute -= OnPlayAgainClickedEvent;
            viewModel.StarsVariable.OnChange -= OnStarsVariableChanged;
        }

        private void OnStarsVariableChanged(int value)
        {
            useCases.ShowStarsUseCase.Execute(value);
        }

        private void OnPlayAgainClickedEvent(StageCompletedUIView stageCompletedUIView, PointerCallbacks pointerCallbacks)
        {
            useCases.PlayAgainUseCase.Execute();
        }
    }
}
