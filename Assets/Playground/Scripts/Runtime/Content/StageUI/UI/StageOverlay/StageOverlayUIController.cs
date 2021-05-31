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
            viewModel.RestartCommand.OnExecute += OnRestartCommand;
            viewModel.SettingsCommand.OnExecute += OnSettingsCommand;
        }

        public void Unsubscribe()
        {
            viewModel.RestartCommand.OnExecute -= OnRestartCommand;
            viewModel.SettingsCommand.OnExecute -= OnSettingsCommand;
        }

        private void OnRestartCommand()
        {
            useCases.RestartSelectedUseCase.Execute();
        }

        private void OnSettingsCommand()
        {
            useCases.SettingsSelectedUseCase.Execute();
        }
    }
}
