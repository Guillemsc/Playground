namespace Playground.Content.StageUI.UI.ScreenCarControls
{
    public class ScreenCarControlsUIController
    {
        private readonly ScreenCarControlsUIViewModel viewModel;
        private readonly ScreenCarControlsUIUseCases useCases;

        public ScreenCarControlsUIController(
            ScreenCarControlsUIViewModel viewModel,
            ScreenCarControlsUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            //viewModel.OnDemoStageButtonClickedEvent.OnExecute += OnDemoStageButtonClicked;

            //useCases.SpawnDemoStagesUseCase.Execute();
        }

        public void Unsubscribe()
        {
            //viewModel.OnDemoStageButtonClickedEvent.Clear();
        }
    }
}
