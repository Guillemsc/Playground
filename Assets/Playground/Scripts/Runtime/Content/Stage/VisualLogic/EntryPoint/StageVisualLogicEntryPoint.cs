using Juce.Core.CleanUp;
using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Juce.CoreUnity.Time;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.UseCases.CleanSections;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnSection;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
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
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            ActionInputDetectionUIInteractor actionInputDetectionUIInteractor = uiViewStackService.GetInteractor<ActionInputDetectionUIInteractor>();

            containerBuilder.Bind<ISequencerTimelines<StageTimeline>>()
                .FromNew()
                .WhenDispose((o) => o.KillAll());

            containerBuilder.Bind<IUnityTimer, UnscaledUnityTimer>()
                .FromNew()
                .WhenInit((c, o) => o.Start());

            containerBuilder.Bind<IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>>>()
                .FromFunction((c) => new ShipEntityViewFactory(
                    visualLogicStageSetup.ShipSetup.ShipEntityView,
                    parent: stageContextReferences.ShipParent
                    ));

            containerBuilder.Bind<ISingleRepository<IDisposable<ShipEntityView>>, SimpleSingleRepository<IDisposable<ShipEntityView>>>()
                .FromNew();

            containerBuilder.Bind<IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>>>()
                .FromFunction((c) => new SectionEntityViewFactory(
                    parent: stageContextReferences.SectionsParent
                    ));

            containerBuilder.Bind<IRepository<IDisposable<SectionEntityView>>, SimpleRepository<IDisposable<SectionEntityView>>>()
                .FromNew();

            containerBuilder.Bind<ShipEntityViewMovementTickable>()
                .FromFunction((c) => new ShipEntityViewMovementTickable(
                    timeService
                    ))
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            //ISequencerTimelines<StageTimeline> sequencerTimelines = new SequencerTimelines<StageTimeline>();
            //AddCleanupAction(sequencerTimelines.KillAll);

            //IUnityTimer unscaledTimer = new UnscaledUnityTimer();
            //unscaledTimer.Start();

            //IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory 
            //    = new ShipEntityViewFactory(
            //        visualLogicStageSetup.ShipSetup.ShipEntityView,
            //        parent: stageContextReferences.ShipParent
            //        );

            //ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository
            //    = new SimpleSingleRepository<IDisposable<ShipEntityView>>();

            //IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>> sectionEntityViewFactory
            //    = new SectionEntityViewFactory(
            //        parent: stageContextReferences.SectionsParent
            //        );

            //IRepository<IDisposable<SectionEntityView>> sectionEntityViewRepository =
            //    new SimpleRepository<IDisposable<SectionEntityView>>();

            //ShipEntityViewMovementTickable shipEntityViewMovementTickable = new ShipEntityViewMovementTickable(
            //    timeService
            //    );
            //tickableService.AddTickable(shipEntityViewMovementTickable);
            //AddCleanupAction(() => tickableService.RemoveTickable(shipEntityViewMovementTickable));

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

            IDespawnSectionUseCase despawnSectionUseCase = new DespawnSectionUseCase(
                sectionEntityViewRepository
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

            ICleanSectionsUseCase cleanSectionsUseCase = new CleanSectionsUseCase(
                shipEntityViewRepository,
                sectionEntityViewRepository,
                stageContextReferences.StageSettings,
                despawnSectionUseCase
                );

            CleanSectionsTickable cleanSectionsTickable = new CleanSectionsTickable(
                cleanSectionsUseCase
                );
            tickableService.AddTickable(cleanSectionsTickable);
            AddCleanupAction(() => tickableService.RemoveTickable(cleanSectionsTickable));

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

            ISetSectionsTickablesActiveUseCase setSectionsTickablesActiveUseCase = new SetSectionsTickablesActiveUseCase(
                generateSectionsTickable,
                cleanSectionsTickable
                );

            IStartStageUseCase startStageUseCase = new StartStageUseCase(
                sequencerTimelines,
                shipEntityViewRepository,
                setSectionsTickablesActiveUseCase,
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
