using Juce.Core.CleanUp;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Juce.CoreUnity.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private readonly ICleanUpActionsRepository cleanUpActionsRepository = new CleanUpActionsRepository();

        private UseCaseRepository useCaseRepository;

        public StageVisualLogicEntryPoint(
            ILoadingToken stageLoadedToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            VisualLogicStageSetup visualLogicStageSetup,
            StageContextReferences stageContextReferences
            )
        {
            ActionInputDetectionUIInteractor actionInputDetectionUIInteractor = uiViewStackService.GetInteractor<ActionInputDetectionUIInteractor>();

            ISequencerTimelines<StageTimeline> sequencerTimelines = new SequencerTimelines<StageTimeline>();
            AddCleanupAction(sequencerTimelines.KillAll);

            IUnityTimer unscaledTimer = new UnscaledUnityTimer();
            unscaledTimer.Start();

            IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory 
                = new ShipEntityViewFactory(
                    visualLogicStageSetup.ShipSetup.ShipEntityView,
                    parent: stageContextReferences.ShipParent
                    );

            IRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository 
                = new SimpleRepository<int, IDisposable<ShipEntityView>>();

            ShipEntityViewMovementTickable shipEntityViewMovementTickable = new ShipEntityViewMovementTickable(
                timeService
                );
            tickableService.AddTickable(shipEntityViewMovementTickable);
            AddCleanupAction(() => tickableService.RemoveTickable(shipEntityViewMovementTickable));

            ITryCreateShipViewUseCase tryCreateShipViewUseCase = new TryCreateShipViewUseCase(
                shipEntityViewFactory,
                shipEntityViewRepository
                );

            ISetupCameraUseCase setupCameraUseCase = new SetupCameraUseCase(
                stageContextReferences.CinemachineVirtualCamera
                );

            ISetActionInputDetectionUIVisibleUseCase setActionInputDetectionUIVisibleUseCase = new SetActionInputDetectionUIVisibleUseCase(
                uiViewStackService
                );

            IStartShipMovementUseCase startShipMovementUseCase = new StartShipMovementUseCase(
                shipEntityViewMovementTickable
                );

            ISetupStageUseCase setupStageUseCase = new SetupStageUseCase(
                stageLoadedToken,
                sequencerTimelines,
                unscaledTimer,
                tryCreateShipViewUseCase,
                setupCameraUseCase,
                setActionInputDetectionUIVisibleUseCase
                );

            IStartStageUseCase startStageUseCase = new StartStageUseCase(
                sequencerTimelines,
                shipEntityViewRepository,
                startShipMovementUseCase
                );

            IInputActionReceivedUseCase inputActionReceivedUseCase = new InputActionReceivedUseCase(
                eventDispatcher
                );

            useCaseRepository = new UseCaseRepository(
                setupStageUseCase,
                startStageUseCase,
                inputActionReceivedUseCase
                );

            eventReceiver.Subscribe((SetupStageOutEvent setupStageOutEvent) =>
            {
                useCaseRepository.SetupStageUseCase.Execute(
                    setupStageOutEvent.ShipEntitySnapshot
                    );
            });

            eventReceiver.Subscribe((StartStageOutEvent startStageOutEvent) =>
            {
                useCaseRepository.StartStageUseCase.Execute(
                    startStageOutEvent.ShipEntitySnapshot
                    );
            });

            actionInputDetectionUIInteractor.InputActionReceived += (
                ActionInputDetectionUIInteractor actionInputDetectionUIInteractor,
                EventArgs eventArgs
                ) =>
            {
                useCaseRepository.InputActionReceivedUseCase.Execute();
            };
        }

        protected void AddCleanupAction(Action action)
        {
            cleanUpActionsRepository.Add(action);
        }

        public void CleanUp()
        {
            cleanUpActionsRepository.CleanUp();
        }
    }
}
