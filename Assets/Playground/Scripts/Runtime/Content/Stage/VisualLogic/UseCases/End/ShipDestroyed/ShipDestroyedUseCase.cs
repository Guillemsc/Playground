using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.FinishStage;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed
{
    public class ShipDestroyedUseCase : IShipDestroyedUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly IStopShipMovementUseCase stopShipMovementUseCase;
        private readonly IFinishStageUseCase finishStageUseCase;

        public ShipDestroyedUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            IStopShipMovementUseCase stopShipMovementUseCase,
            IFinishStageUseCase finishStageUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.stopShipMovementUseCase = stopShipMovementUseCase;
            this.finishStageUseCase = finishStageUseCase;
        }

        public void Execute()
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play(Run);
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            stopShipMovementUseCase.Execute();

            await finishStageUseCase.Execute(cancellationToken);
        }
    }
}
