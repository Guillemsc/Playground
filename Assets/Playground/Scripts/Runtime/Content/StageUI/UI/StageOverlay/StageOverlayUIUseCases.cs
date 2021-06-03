using Playground.Content.StageUI.UI.StageOverlay.UseCases;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIUseCases
    {
        public IRestartSelectedUseCase RestartSelectedUseCase { get; }
        public ISettingsSelectedUseCase SettingsSelectedUseCase { get; }
        public ISetTimerTimeUseCase SetTimerTimeUseCase { get; }

        public StageOverlayUIUseCases(
            IRestartSelectedUseCase restartSelectedUseCase,
            ISettingsSelectedUseCase settingsSelectedUseCase,
            ISetTimerTimeUseCase setTimerTimeUseCase
            )
        {
            RestartSelectedUseCase = restartSelectedUseCase;
            SettingsSelectedUseCase = settingsSelectedUseCase;
            SetTimerTimeUseCase = setTimerTimeUseCase;
        }
    }
}
