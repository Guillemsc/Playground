using Juce.Core.Disposables;
using Juce.Core.Sequencing;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupStage
{
    public class SetupStageUseCase : ISetupStageUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly ITryCreateShipViewUseCase tryCreateShipViewUseCase;
        private readonly ISetupCameraUseCase setupCameraUseCase;
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;
        private readonly IStartShipMovementUseCase startShipMovementUseCase;

        public SetupStageUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            ITryCreateShipViewUseCase tryCreateShipViewUseCase,
            ISetupCameraUseCase setupCameraUseCase,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase,
            IStartShipMovementUseCase startShipMovementUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.tryCreateShipViewUseCase = tryCreateShipViewUseCase;
            this.setupCameraUseCase = setupCameraUseCase;
            this.setActionInputDetectionUIVisibleUseCase = setActionInputDetectionUIVisibleUseCase;
            this.startShipMovementUseCase = startShipMovementUseCase;
        }

        public void Execute(
            ShipEntitySnapshot shipEntitySnapshot
            )
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play((ct) => Run(shipEntitySnapshot, ct));
        }

        public async Task Run(
            ShipEntitySnapshot shipEntitySnapshot,
            CancellationToken cancellationToken
            )
        {
            bool created = tryCreateShipViewUseCase.Execute(
                shipEntitySnapshot,
                out IDisposable<ShipEntityView> shipEntityView
                );

            if(!created)
            {
                return;
            }

            setupCameraUseCase.Execute(shipEntityView);

            startShipMovementUseCase.Execute(shipEntityView);

            await setActionInputDetectionUIVisibleUseCase.Execute(visible: true, instantly: false, cancellationToken);
        }
    }
}
