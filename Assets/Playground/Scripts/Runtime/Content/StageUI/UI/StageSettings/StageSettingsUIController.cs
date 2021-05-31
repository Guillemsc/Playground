namespace Playground.Content.StageUI.UI.StageSettings
{
    public class StageSettingsUIController
    {
        private readonly StageSettingsUIViewModel viewModel;
        private readonly StageSettingsUIUseCases useCases;

        public StageSettingsUIController(
            StageSettingsUIViewModel viewModel,
            StageSettingsUIUseCases useCases
            )
        {
            this.viewModel = viewModel;
            this.useCases = useCases;
        }

        public void Subscribe()
        {
            viewModel.ClosePanelCommand.OnExecute += OnClosePanelCommand;
            viewModel.ExitStageCommand.OnExecute += OnExistStageCommand;
        }

        public void Unsubscribe()
        {
            viewModel.ClosePanelCommand.OnExecute -= OnClosePanelCommand;
            viewModel.ExitStageCommand.OnExecute -= OnExistStageCommand;
        }

        private void OnClosePanelCommand()
        {
            useCases.ClosePanelSelectedUseCase.Execute();
        }

        private void OnExistStageCommand()
        {
            useCases.ExitStageSelectedUseCase.Execute();
        }
    }
}
