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
            viewModel.StarsVariable.OnChange += OnStarsVariableChanged;
            viewModel.ContinueEvent.OnExecute += OnContinueEvent;
            viewModel.PlayAgainEvent.OnExecute += OnPlayAgainEvent;
        }

        public void Unsubscribe()
        {
            viewModel.StarsVariable.OnChange -= OnStarsVariableChanged;
            viewModel.ContinueEvent.OnExecute += OnContinueEvent;
            viewModel.PlayAgainEvent.OnExecute -= OnPlayAgainEvent;
        }

        private void OnStarsVariableChanged(int value)
        {
            useCases.ShowStarsUseCase.Execute(value);
        }

        private void OnContinueEvent(StageCompletedUIView stageCompletedUIView, PointerCallbacks pointerCallbacks)
        {
            useCases.ContinueUseCase.Execute();
        }

        private void OnPlayAgainEvent(StageCompletedUIView stageCompletedUIView, PointerCallbacks pointerCallbacks)
        {
            useCases.PlayAgainUseCase.Execute();
        }
    }
}
