using Playground.Content.StageUI.UI.StageOverlay.UseCases;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIUseCases
    {
        public IRestartSelectedUseCase RestartSelectedUseCase { get; }
        public ISettingsSelectedUseCase SettingsSelectedUseCase { get; }

        public StageOverlayUIUseCases(
            IRestartSelectedUseCase restartSelectedUseCase,
            ISettingsSelectedUseCase settingsSelectedUseCase
            )
        {
            RestartSelectedUseCase = restartSelectedUseCase;
            SettingsSelectedUseCase = settingsSelectedUseCase;
        }
    }
}
