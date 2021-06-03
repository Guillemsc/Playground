using Playground.Content.Stage.VisualLogic.View.Signals;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetStageTimerPlayingInstruction
    {
        private readonly StageTimerState stageTimerState;
        private readonly bool playing;

        public SetStageTimerPlayingInstruction(
            StageTimerState stageTimerState,
            bool playing
            )
        {
            this.stageTimerState = stageTimerState;
            this.playing = playing;
        }

        public void Execute()
        {
            if(playing)
            {
                stageTimerState.Timer.Start();
            }
            else
            {
                stageTimerState.Timer.Pause();
            }
        }
    }
}
