using Juce.Core.Sequencing;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class CurrentCheckPointChangedUseCase : ICurrentCheckPointChangedUseCase
    {
        private readonly Sequencer sequencer;

        public CurrentCheckPointChangedUseCase(Sequencer sequencer)
        {
            this.sequencer = sequencer;
        }

        public void Execute(int checkPointIndex)
        {

        }
    }
}
