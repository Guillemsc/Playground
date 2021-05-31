using Playground.Services.ViewStack;

namespace Playground.Content.StageUI.UI.StageSettings.UseCases
{
    public class ExitStageSelectedUseCase : IExitStageSelectedUseCase
    {
        private readonly StageSettingsUIViewModel viewModel;

        public ExitStageSelectedUseCase(StageSettingsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute()
        {
            viewModel.RegisteredExitStageCallbacks?.Invoke();
        }
    }
}
