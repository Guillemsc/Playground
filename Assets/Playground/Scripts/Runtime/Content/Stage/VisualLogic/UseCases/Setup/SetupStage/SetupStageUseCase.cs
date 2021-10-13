using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.Core.Sequencing;
using Juce.Core.Time;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupStage
{
    public class SetupStageUseCase : ISetupStageUseCase
    {
        private readonly ILoadingToken stageLoadedToken;
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly ITimer timer;
        private readonly ITryCreateShipViewUseCase tryCreateShipViewUseCase;
        private readonly IGenerateSectionsUseCase generateSectionsUseCase;
        private readonly ISetupCameraUseCase setupCameraUseCase;
        private readonly ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase;

        public SetupStageUseCase(
            ILoadingToken stageLoadedToken,
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            ITimer timer,
            ITryCreateShipViewUseCase tryCreateShipViewUseCase,
            IGenerateSectionsUseCase generateSectionsUseCase,
            ISetupCameraUseCase setupCameraUseCase,
            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase
            )
        {
            this.stageLoadedToken = stageLoadedToken;
            this.sequencerTimelines = sequencerTimelines;
            this.timer = timer;
            this.tryCreateShipViewUseCase = tryCreateShipViewUseCase;
            this.generateSectionsUseCase = generateSectionsUseCase;
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

            generateSectionsUseCase.Execute();

            setupCameraUseCase.Execute();

            stageLoadedToken.Complete();

            timer.Start();
            await timer.AwaitTime(TimeSpan.FromSeconds(0.5f), cancellationToken);

            await setActionInputDetectionUIVisibleUseCase.Execute(visible: true, instantly: false, cancellationToken);
        }
    }
}
