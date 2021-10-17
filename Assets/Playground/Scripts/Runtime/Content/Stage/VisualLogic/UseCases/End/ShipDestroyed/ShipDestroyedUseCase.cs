using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.FinishStage;
using Playground.Content.Stage.VisualLogic.UseCases.KillShip;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed
{
    public class ShipDestroyedUseCase : IShipDestroyedUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly IStopShipMovementUseCase stopShipMovementUseCase;
        private readonly IKillShipUseCase killShipUseCase;
        private readonly IFinishStageUseCase finishStageUseCase;

        public ShipDestroyedUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            IStopShipMovementUseCase stopShipMovementUseCase,
            IKillShipUseCase killShipUseCase,
            IFinishStageUseCase finishStageUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.stopShipMovementUseCase = stopShipMovementUseCase;
            this.killShipUseCase = killShipUseCase;
            this.finishStageUseCase = finishStageUseCase;
        }

        public void Execute()
        {
            ISequencer sequencer = sequencerTimelines.GetOrCreateTimeline(StageTimeline.Main);

            sequencer.Play(Run);
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            bool shipEntityFound = shipEntityViewRepository.TryGet(out IDisposable<ShipEntityView> shipEntityView);

            if (!shipEntityFound)
            {
                UnityEngine.Debug.LogError($"{nameof(ShipEntityView)} not found, " +
                    $"at {nameof(ShipDestroyedUseCase)}");
                return;
            }

            stopShipMovementUseCase.Execute();

            await killShipUseCase.Execute(shipEntityView.Value, cancellationToken);

            await finishStageUseCase.Execute(cancellationToken);
        }
    }
}
