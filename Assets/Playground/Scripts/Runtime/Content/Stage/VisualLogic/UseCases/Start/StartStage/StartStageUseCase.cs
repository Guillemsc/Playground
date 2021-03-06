using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointsUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection;
using Playground.Content.Stage.VisualLogic.UseCases.StartShip;
using Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly ISequencerTimelines<StageTimeline> sequencerTimelines;
        private readonly InputState inputState;
        private readonly IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly ISetSectionsTickablesActiveUseCase setSectionsTickablesActiveUseCase;
        private readonly ISetPointGoalsTickablesActiveUseCase setPointGoalsTickablesActiveUseCase;
        private readonly IModifyCameraOnceStartsUseCase modifyCameraOnceStartsUseCase;
        private readonly IStartShipMovementUseCase startShipMovementUseCase;
        private readonly IStartShipUseCase startShipUseCase;
        private readonly ISetMainStageUIVisibleUseCase setMainStageUIVisibleUseCase;
        private readonly IStartDirectionSelectionUseCase startDirectionSelectionUseCase;

        public StartStageUseCase(
            ISequencerTimelines<StageTimeline> sequencerTimelines,
            InputState inputState,
            IReadOnlySingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            ISetSectionsTickablesActiveUseCase setSectionsTickablesActiveUseCase,
            ISetPointGoalsTickablesActiveUseCase setPointGoalsTickablesActiveUseCase,
            IModifyCameraOnceStartsUseCase modifyCameraOnceStartsUseCase,
            IStartShipMovementUseCase startShipMovementUseCase,
            IStartShipUseCase startShipUseCase,
            ISetMainStageUIVisibleUseCase setMainStageUIVisibleUseCase,
            IStartDirectionSelectionUseCase startDirectionSelectionUseCase
            )
        {
            this.sequencerTimelines = sequencerTimelines;
            this.inputState = inputState;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.setSectionsTickablesActiveUseCase = setSectionsTickablesActiveUseCase;
            this.setPointGoalsTickablesActiveUseCase = setPointGoalsTickablesActiveUseCase;
            this.modifyCameraOnceStartsUseCase = modifyCameraOnceStartsUseCase;
            this.startShipMovementUseCase = startShipMovementUseCase;
            this.startShipUseCase = startShipUseCase;
            this.setMainStageUIVisibleUseCase = setMainStageUIVisibleUseCase;
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
                UnityEngine.Debug.LogError($"{nameof(ShipEntityView)} not found, " +
                    $"at {nameof(StartStageUseCase)}");
                return Task.CompletedTask;
            }

            setSectionsTickablesActiveUseCase.Execute(active: true);
            setPointGoalsTickablesActiveUseCase.Execute(active: true);

            modifyCameraOnceStartsUseCase.Execute(shipEntityView.Value);

            startShipUseCase.Execute(shipEntityView.Value, cancellationToken).RunAsync();

            startShipMovementUseCase.Execute(shipEntityView.Value);

            setMainStageUIVisibleUseCase.Execute(visible: true, instantly: false, cancellationToken).RunAsync();

            startDirectionSelectionUseCase.Execute();

            inputState.CanChangeShipDirection = true;

            return Task.CompletedTask;
        }
    }
}
