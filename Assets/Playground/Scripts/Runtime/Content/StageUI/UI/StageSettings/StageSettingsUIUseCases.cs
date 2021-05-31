using Playground.Content.StageUI.UI.StageSettings.UseCases;

namespace Playground.Content.StageUI.UI.StageSettings
{
    public class StageSettingsUIUseCases
    {
        public IClosePanelSelectedUseCase ClosePanelSelectedUseCase { get; }
        public IExitStageSelectedUseCase ExitStageSelectedUseCase { get; }

        public StageSettingsUIUseCases(
            IClosePanelSelectedUseCase closePanelSelectedUseCase,
            IExitStageSelectedUseCase exitStageSelectedUseCase
            )
        {
            ClosePanelSelectedUseCase = closePanelSelectedUseCase;
            ExitStageSelectedUseCase = exitStageSelectedUseCase;
        }
    }
}
