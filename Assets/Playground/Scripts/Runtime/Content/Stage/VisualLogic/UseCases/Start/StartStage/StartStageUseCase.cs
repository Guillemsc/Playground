using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly IKeyValueRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IStartShipMovementUseCase startShipMovementUseCase;

        public StartStageUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            IKeyValueRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository,
            IStartShipMovementUseCase startShipMovementUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.startShipMovementUseCase = startShipMovementUseCase;
        }

        public void Execute(
        ShipEntitySnapshot shipEntitySnapshot
        )
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play((ct) => Run(shipEntitySnapshot, ct));
        }

        public Task Run(
            ShipEntitySnapshot shipEntitySnapshot,
            CancellationToken cancellationToken
            )
        {
            bool shipEntityFound = shipEntityViewRepository.TryGet(
                shipEntitySnapshot.InstanceId,
                out IDisposable<ShipEntityView> shipEntityView
                );

            if(!shipEntityFound)
            {
                return Task.CompletedTask;
            }

            startShipMovementUseCase.Execute(shipEntityView);

            return Task.CompletedTask;
        }
    }
}
