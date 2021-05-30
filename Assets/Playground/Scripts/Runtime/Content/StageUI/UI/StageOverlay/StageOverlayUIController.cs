namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIController
    {
        private readonly StageOverlayUIViewModel viewModel;
        private readonly StageOverlayUIUseCases useCases;

        public StageOverlayUIController(
            StageOverlayUIViewModel viewModel,
            StageOverlayUIUseCases useCases
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
