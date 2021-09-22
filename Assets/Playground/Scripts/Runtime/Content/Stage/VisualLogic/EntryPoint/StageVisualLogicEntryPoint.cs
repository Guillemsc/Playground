using Juce.Core.CleanUp;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Juce.CoreUnity.Time;
using Playground.Configuration.Stage;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.SetTickableSectionGeneratorActive;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSection;
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

            ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository 
                = new SimpleSingleRepository<IDisposable<ShipEntityView>>();

            IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>> sectionEntityViewFactory
                = new SectionEntityViewFactory(
                    parent: stageContextReferences.SectionsParent
                    );

            IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository =
                new SimpleRepository<IDisposable<SectionEntityView>>();

            ShipEntityViewMovementTickable shipEntityViewMovementTickable = new ShipEntityViewMovementTickable(
                timeService
                );
            tickableService.AddTickable(shipEntityViewMovementTickable);
            AddCleanupAction(() => tickableService.RemoveTickable(shipEntityViewMovementTickable));

            ITryCreateShipViewUseCase tryCreateShipViewUseCase = new TryCreateShipViewUseCase(
                shipEntityViewFactory,
                shipEntityViewRepository,
                stageContextReferences.ShipStartPosition
                );

            ITrySpawnRandomSectionUseCase trySpawnSectionsUseCase = new TrySpawnRandomSectionUseCase(
                sectionEntityViewFactory,
                sectionEntityViewRepository,
                stageContextReferences.SectionsStartPosition,
                visualLogicStageSetup.SectionsSetup
                );

            IGenerateSectionsUseCase generateSectionsUseCase = new GenerateSectionsUseCase(
                shipEntityViewRepository,
                sectionEntityViewRepository,
                stageContextReferences.SectionsStartPosition,
                visualLogicStageSetup.SectionsSetup,
                stageContextReferences.StageSettings,
                trySpawnSectionsUseCase
                );

            GenerateSectionsTickable generateSectionsTickable = new GenerateSectionsTickable(
                generateSectionsUseCase
                );
            tickableService.AddTickable(generateSectionsTickable);
            AddCleanupAction(() => tickableService.RemoveTickable(generateSectionsTickable));

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
                generateSectionsUseCase,
                setupCameraUseCase,
                setActionInputDetectionUIVisibleUseCase
                );

            ISetTickableSectionGeneratorActiveUseCase setTickableSectionGeneratorActiveUseCase = new SetTickableSectionGeneratorActiveUseCase(
                generateSectionsTickable
                );

            IStartStageUseCase startStageUseCase = new StartStageUseCase(
                sequencerTimelines,
                shipEntityViewRepository,
                setTickableSectionGeneratorActiveUseCase,
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
