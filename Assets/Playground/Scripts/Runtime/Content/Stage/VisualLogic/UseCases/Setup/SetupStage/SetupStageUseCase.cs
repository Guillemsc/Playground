using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Time;
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
        private readonly ILoadingToken stageLoadedToken;
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly IUnityTimer unscaledUnityTimer;
        private readonly ITryCreateShipViewUseCase tryCreateShipViewUseCase;
        private readonly ISetupCameraUseCase setupCameraUseCase;
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;

        public SetupStageUseCase(
            ILoadingToken stageLoadedToken,
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            IUnityTimer unscaledUnityTimer,
            ITryCreateShipViewUseCase tryCreateShipViewUseCase,
            ISetupCameraUseCase setupCameraUseCase,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase
            )
        {
            this.stageLoadedToken = stageLoadedToken;
            this.sequencerTimelines = sequencerTimelines;
            this.unscaledUnityTimer = unscaledUnityTimer;
            this.tryCreateShipViewUseCase = tryCreateShipViewUseCase;
            this.setupCameraUseCase = setupCameraUseCase;
            this.setActionInputDetectionUIVisibleUseCase = setActionInputDetectionUIVisibleUseCase;
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

            stageLoadedToken.Complete();

            await unscaledUnityTimer.AwaitTime(0.5f, cancellationToken);

            await setActionInputDetectionUIVisibleUseCase.Execute(visible: true, instantly: false, cancellationToken);
        }
    }
}
