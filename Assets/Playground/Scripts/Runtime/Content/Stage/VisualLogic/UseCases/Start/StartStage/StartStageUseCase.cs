using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.SetTickableSectionGeneratorActive;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly ISetTickableSectionGeneratorActiveUseCase setTickableSectionGeneratorActiveUseCase;
        private readonly IStartShipMovementUseCase startShipMovementUseCase;

        public StartStageUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            ISetTickableSectionGeneratorActiveUseCase setTickableSectionGeneratorActiveUseCase,
            IStartShipMovementUseCase startShipMovementUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.setTickableSectionGeneratorActiveUseCase = setTickableSectionGeneratorActiveUseCase;
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
            bool shipEntityFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if (!shipEntityFound)
            {
                return Task.CompletedTask;
            }

            setTickableSectionGeneratorActiveUseCase.Execute(active: true);

            startShipMovementUseCase.Execute(shipEntityView);

            return Task.CompletedTask;
        }
    }
}
