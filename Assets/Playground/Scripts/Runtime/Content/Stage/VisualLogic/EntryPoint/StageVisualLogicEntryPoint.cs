using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Playground.Configuration.Stage;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private UseCaseRepository useCaseRepository;

        public StageVisualLogicEntryPoint(
            ILoadingToken stageLoadedToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            StageConfiguration stageConfiguration,
            StageContextReferences stageContextReferences
            )
        {
            ISequencerTimelines<StageTimeline> sequencerTimelines = new SequencerTimelines<StageTimeline>();

            IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory 
                = new ShipEntityViewFactory(
                    stageConfiguration.ShipConfiguration.DefaultShipEntityView,
                    parent: stageContextReferences.ShipParent
                    );

            IRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository 
                = new SimpleRepository<int, IDisposable<ShipEntityView>>();

            ShipEntityViewMovementTickable shipEntityViewMovementTickable = new ShipEntityViewMovementTickable(
                timeService
                );
            tickableService.AddTickable(shipEntityViewMovementTickable);

            ITryCreateShipViewUseCase tryCreateShipViewUseCase = new TryCreateShipViewUseCase(
                shipEntityViewFactory,
                shipEntityViewRepository
                );

            ISetupCameraUseCase setupCameraUseCase = new SetupCameraUseCase(
                stageContextReferences.CinemachineVirtualCamera
                );

            IStartShipMovementUseCase startShipMovementUseCase = new StartShipMovementUseCase(
                shipEntityViewMovementTickable
                );

            ISetupStageUseCase setupStageUseCase = new SetupStageUseCase(
                sequencerTimelines,
                tryCreateShipViewUseCase,
                setupCameraUseCase,
                startShipMovementUseCase
                );

            useCaseRepository = new UseCaseRepository(
                setupStageUseCase
                );

            eventReceiver.Subscribe((SetupStageOutEvent setupStageOutEvent) =>
            {
                useCaseRepository.SetupStageUseCase.Execute(
                    setupStageOutEvent.ShipEntitySnapshot
                    );
            });

            stageLoadedToken.Complete();
        }
    }
}
