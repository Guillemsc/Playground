using Juce.Core.Sequencing;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class StageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly Sequencer sequencer;

        public StageFinishedUseCase(
            Sequencer sequencer
            )
        {
            this.sequencer = sequencer;
        }

        public void Execute()
        {

        }
    }
}
