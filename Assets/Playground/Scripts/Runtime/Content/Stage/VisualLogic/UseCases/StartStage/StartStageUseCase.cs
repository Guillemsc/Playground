using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Signals;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly StageTimerState stageTimerState;

        public StartStageUseCase(StageTimerState stageTimerState)
        {
            this.stageTimerState = stageTimerState;
        }

        public void Execute()
        {
            new SetStageTimerPlayingInstruction(
                stageTimerState,
                playing: true
                ).Execute();
        }
    }
}
