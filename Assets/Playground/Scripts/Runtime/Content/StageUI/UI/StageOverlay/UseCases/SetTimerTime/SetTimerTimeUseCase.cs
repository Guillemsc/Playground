using System;

namespace Playground.Content.StageUI.UI.StageOverlay.UseCases
{
    public class SetTimerTimeUseCase : ISetTimerTimeUseCase
    {
        private readonly StageOverlayUIViewModel stageOverlayUIViewModel;

        public SetTimerTimeUseCase(StageOverlayUIViewModel stageOverlayUIViewModel)
        {
            this.stageOverlayUIViewModel = stageOverlayUIViewModel;
        }

        public void Execute(TimeSpan timeSpan)
        {
            stageOverlayUIViewModel.TimerVariable.Value = timeSpan.ToString(@"mm\:ss");
        }
    }
}
