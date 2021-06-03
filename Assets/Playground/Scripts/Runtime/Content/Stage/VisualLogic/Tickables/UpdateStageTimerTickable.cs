using Juce.Core.Tickable;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.StageUI.UI.StageOverlay;

namespace Playground.Content.Stage.VisualLogic.Tickable
{
    public class UpdateStageTimerTickable : ITickable
    {
        private readonly StageOverlayUIInteractor stageOverlayUIInteractor;
        private readonly StageTimerState stageTimerState;

        public UpdateStageTimerTickable(
            StageOverlayUIInteractor stageOverlayUIInteractor,
            StageTimerState stageTimerState
            )
        {
            this.stageOverlayUIInteractor = stageOverlayUIInteractor;
            this.stageTimerState = stageTimerState;
        }

        public void Tick()
        {
            stageOverlayUIInteractor.SetTimerTime(stageTimerState.Timer.Time);
        }
    }
}
