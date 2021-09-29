﻿using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Juce.CoreUnity.Time;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Tickables;
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
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class UseCasesInstaller : IInstaller
    {
        private readonly ILoadingToken stageLoadedToken;
        private readonly IEventDispatcher eventDispatcher;
        private readonly TickablesService tickableService;
        private readonly TimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly PersistenceService persistenceService;
        private readonly VisualLogicStageSetup visualLogicStageSetup;
        private readonly StageContextReferences stageContextReferences;

        public UseCasesInstaller(
            ILoadingToken stageLoadedToken,
            IEventDispatcher eventDispatcher,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            VisualLogicStageSetup visualLogicStageSetup,
            StageContextReferences stageContextReferences
            )
        {
            this.stageLoadedToken = stageLoadedToken;
            this.eventDispatcher = eventDispatcher;
            this.tickableService = tickableService;
            this.timeService = timeService;
            this.uiViewStackService = uiViewStackService;
            this.persistenceService = persistenceService;
            this.visualLogicStageSetup = visualLogicStageSetup;
            this.stageContextReferences = stageContextReferences;
        }

        public void Install(IDIContainerBuilder containerBuilder)
        {
            containerBuilder.Bind<ISequencerTimelines<StageTimeline>, SequencerTimelines<StageTimeline>>()
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


            containerBuilder.Bind<ITryCreateShipViewUseCase>()
                .FromFunction((c) => new TryCreateShipViewUseCase(
                    c.Resolve<IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    stageContextReferences.ShipStartPosition
                    ));

            containerBuilder.Bind<ITrySpawnRandomSectionUseCase>()
                .FromFunction((c) => new TrySpawnRandomSectionUseCase(
                    c.Resolve<IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.SectionsStartPosition,
                    visualLogicStageSetup.SectionsSetup
                    ));

            containerBuilder.Bind<IDespawnSectionUseCase>()
                .FromFunction((c) => new DespawnSectionUseCase(
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>()
                    ));

            containerBuilder.Bind<IGenerateSectionsUseCase>()
                .FromFunction((c) => new GenerateSectionsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.SectionsStartPosition,
                    visualLogicStageSetup.SectionsSetup,
                    stageContextReferences.StageSettings,
                    c.Resolve<ITrySpawnRandomSectionUseCase>()
                    ));

            containerBuilder.Bind<GenerateSectionsTickable>()
                .FromFunction((c) => new GenerateSectionsTickable(
                    c.Resolve<IGenerateSectionsUseCase>()
                    ))
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            containerBuilder.Bind<ICleanSectionsUseCase>()
                .FromFunction((c) => new CleanSectionsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.StageSettings,
                    c.Resolve<IDespawnSectionUseCase>()
                    ));

            containerBuilder.Bind<CleanSectionsTickable>()
                .FromFunction((c) => new CleanSectionsTickable(
                    c.Resolve<ICleanSectionsUseCase>()
                    ))
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            containerBuilder.Bind<ISetupCameraUseCase>()
                .FromFunction((c) => new SetupCameraUseCase(
                    stageContextReferences.CinemachineVirtualCamera
                    ));

            containerBuilder.Bind<ISetActionInputDetectionUIVisibleUseCase>()
                .FromFunction((c) => new SetActionInputDetectionUIVisibleUseCase(
                    uiViewStackService
                    ));

            containerBuilder.Bind<IStartShipMovementUseCase>()
                .FromFunction((c) => new StartShipMovementUseCase(
                    c.Resolve<ShipEntityViewMovementTickable>()
                    ));

            containerBuilder.Bind<ISetupStageUseCase>()
                .FromFunction((c) => new SetupStageUseCase(
                    stageLoadedToken,
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<IUnityTimer>(),
                    c.Resolve<ITryCreateShipViewUseCase>(),
                    c.Resolve<IGenerateSectionsUseCase>(),
                    c.Resolve<ISetupCameraUseCase>(),
                    c.Resolve<ISetActionInputDetectionUIVisibleUseCase>()
                    ));

            containerBuilder.Bind<ISetSectionsTickablesActiveUseCase>()
                .FromFunction((c) => new SetSectionsTickablesActiveUseCase(
                    c.Resolve<GenerateSectionsTickable>(),
                    c.Resolve<CleanSectionsTickable>()
                    ));

            containerBuilder.Bind<IStartStageUseCase>()
                .FromFunction((c) => new StartStageUseCase(
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISetSectionsTickablesActiveUseCase>(),
                    c.Resolve<IStartShipMovementUseCase>()
                    ));

            containerBuilder.Bind<IInputActionReceivedUseCase>()
                .FromFunction((c) => new InputActionReceivedUseCase(
                    eventDispatcher
                    ));

        }
    }
}
