using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection;
using Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly ISetSectionsTickablesActiveUseCase setSectionsTickablesActiveUseCase;
        private readonly IModifyCameraOnceStartsUseCase modifyCameraOnceStartsUseCase;
        private readonly IStartShipMovementUseCase startShipMovementUseCase;
        private readonly ISetDirectionSelectorUIVisibleUseCase setDirectionSelectorUIVisibleUseCase;
        private readonly IStartDirectionSelectionUseCase startDirectionSelectionUseCase;

        public StartStageUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            ISetSectionsTickablesActiveUseCase setSectionsTickablesActiveUseCase,
            IModifyCameraOnceStartsUseCase modifyCameraOnceStartsUseCase,
            IStartShipMovementUseCase startShipMovementUseCase,
            ISetDirectionSelectorUIVisibleUseCase setDirectionSelectorUIVisibleUseCase,
            IStartDirectionSelectionUseCase startDirectionSelectionUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.setSectionsTickablesActiveUseCase = setSectionsTickablesActiveUseCase;
            this.modifyCameraOnceStartsUseCase = modifyCameraOnceStartsUseCase;
            this.startShipMovementUseCase = startShipMovementUseCase;
            this.setDirectionSelectorUIVisibleUseCase = setDirectionSelectorUIVisibleUseCase;
            this.startDirectionSelectionUseCase = startDirectionSelectionUseCase;
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

            setSectionsTickablesActiveUseCase.Execute(active: true);

            modifyCameraOnceStartsUseCase.Execute(shipEntityView.Value);

            startShipMovementUseCase.Execute(shipEntityView.Value);

            setDirectionSelectorUIVisibleUseCase.Execute(visible: true, instantly: false, cancellationToken).RunAsync();

            startDirectionSelectionUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}
