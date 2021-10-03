using Juce.Core.Sequencing;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed
{
    public class ShipDestroyedUseCase : IShipDestroyedUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly ITimer timer;
        private readonly StageSettings stageSettings;
        private readonly IStopShipMovementUseCase stopShipMovementUseCase;
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;
        private readonly IStageFinishedUseCase stageFinishedUseCase;

        public ShipDestroyedUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            ITimer timer,
            StageSettings stageSettings,
            IStopShipMovementUseCase stopShipMovementUseCase,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase,
            IStageFinishedUseCase stageFinishedUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.timer = timer;
            this.stageSettings = stageSettings;
            this.stopShipMovementUseCase = stopShipMovementUseCase;
            this.setActionInputDetectionUIVisibleUseCase = setActionInputDetectionUIVisibleUseCase;
            this.stageFinishedUseCase = stageFinishedUseCase;
        }

        public void Execute()
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play(Run);
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            stopShipMovementUseCase.Execute();

            setActionInputDetectionUIVisibleUseCase.Execute(
                visible: false, 
                instantly: true, 
                CancellationToken.None
                ).RunAsync();

            timer.Start();
            await timer.AwaitReach(TimeSpan.FromSeconds(stageSettings.DelayOnStageFinished), cancellationToken);

            stageFinishedUseCase.Execute();
        }
    }
}
