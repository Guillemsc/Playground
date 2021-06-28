using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Stage;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class CurrentCheckPointChangedUseCase : ICurrentCheckPointChangedUseCase
    {
        private readonly Sequencer sequencer;
        private readonly StageViewRepository stageViewRepository;

        public CurrentCheckPointChangedUseCase(
            Sequencer sequencer,
            StageViewRepository stageViewRepository
            )
        {
            this.sequencer = sequencer;
            this.stageViewRepository = stageViewRepository;
        }

        public void Execute(int checkPointIndex)
        {
            sequencer.Play(() => ExecuteSequence(checkPointIndex));
        }

        private void ExecuteSequence(int checkPointIndex)
        {
            StageView stageView = stageViewRepository.Item;

            new SetCheckPointAsCrossed(stageView.CheckPointsView, checkPointIndex).Execute();
        }
    }
}
