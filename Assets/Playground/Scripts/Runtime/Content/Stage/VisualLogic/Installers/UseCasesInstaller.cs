using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Loading;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Stats;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases.CleanSections;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnSection;
using Playground.Content.Stage.VisualLogic.UseCases.FinishStage;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.GetDirectionSelectionValue;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollided;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed;
using Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection;
using Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSection;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.ViewStack;
using Playground.Content.Stage.VisualLogic.UseCases.ChangeShipDirection;
using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Effects;
using Playground.Content.Stage.VisualLogic.UseCases.RemoveEffect;
using Playground.Content.Stage.VisualLogic.UseCases.AddEffect;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect;
using Playground.Content.StageUI.UI.Effects;
using Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class UseCasesInstaller : IInstaller
    {
        private readonly ILoadingToken stageLoadedToken;
        private readonly IStageFinishedUseCase stageFinishedUseCase;
        private readonly IEventDispatcher eventDispatcher;
        private readonly TickablesService tickableService;
        private readonly TimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly PersistenceService persistenceService;
        private readonly StageVisualLogicSetup visualLogicStageSetup;
        private readonly StageContextReferences stageContextReferences;

        public UseCasesInstaller(
            ILoadingToken stageLoadedToken,
            IStageFinishedUseCase stageFinishedUseCase,
            IEventDispatcher eventDispatcher,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextReferences stageContextReferences
            )
        {
            this.stageLoadedToken = stageLoadedToken;
            this.stageFinishedUseCase = stageFinishedUseCase;
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

            containerBuilder.Bind<InputState>().FromNew();
            containerBuilder.Bind<DirectionSelectionState>().FromNew();

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

            containerBuilder.Bind<TimeTriggersTickable>()
                .FromNew()
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            containerBuilder.Bind<IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>>>()
                .FromFunction(c => new EffectsFactory(
                    c.Resolve<TimeTriggersTickable>(),
                    c.Resolve<ShipStats>(),
                    timeService.ScaledTimeContext
                    ));

            containerBuilder.Bind<IRepository<IDisposable<EffectWithTriggerExpirator>>, SimpleRepository<IDisposable<EffectWithTriggerExpirator>>>()
                .FromNew();

            containerBuilder.Bind<IGetDirectionSelectionValueUseCase>()
                .FromFunction(c => new GetDirectionSelectionValueUseCase(
                    visualLogicStageSetup.DirectionSelectorSetup
                    ));

            containerBuilder.Bind<DirectionSelectionValueTickable>()
                .FromFunction(c => new DirectionSelectionValueTickable(
                    timeService.ScaledTimeContext.NewTimer(),
                    c.Resolve<DirectionSelectionState>(),
                    c.Resolve<IDirectionSelectorUIInteractor>(),
                    c.Resolve<IGetDirectionSelectionValueUseCase>()
                    ))
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            containerBuilder.Bind<ShipEntityViewMovementTickable>()
                .FromFunction(c => new ShipEntityViewMovementTickable(
                    timeService,
                    c.Resolve<ShipStats>(),
                    c.Resolve<DirectionSelectionState>()
                    ))
                .WhenInit((c, o) => tickableService.AddTickable(o))
                .WhenDispose((o) => tickableService.RemoveTickable(o));

            containerBuilder.Bind<IStartShipMovementUseCase>()
                .FromFunction((c) => new StartShipMovementUseCase(
                    c.Resolve<ShipEntityViewMovementTickable>()
                    ));

            containerBuilder.Bind<IStopShipMovementUseCase>()
                .FromFunction((c) => new StopShipMovementUseCase(
                    c.Resolve<ShipEntityViewMovementTickable>()
                    ));

            containerBuilder.Bind<IShipCollidedWithDeadlyCollisionUseCase>()
                .FromFunction((c) => new ShipCollidedWithDeadlyCollisionUseCase(
                    eventDispatcher
                    ));

            containerBuilder.Bind<IShipCollidedWithEffectUseCase>()
                .FromFunction(c => new ShipCollidedWithEffectUseCase(
                    c.Resolve<IAddEffectUseCase>()
                    ));

            containerBuilder.Bind<IShipCollidedUseCase>()
                .FromFunction((c) => new ShipCollidedUseCase(
                    c.Resolve<IShipCollidedWithDeadlyCollisionUseCase>(),
                    c.Resolve<IShipCollidedWithEffectUseCase>()
                    ));

            containerBuilder.Bind<ITryCreateShipViewUseCase>()
                .FromFunction((c) => new TryCreateShipViewUseCase(
                    c.Resolve<IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    stageContextReferences.ShipStartPosition,
                    c.Resolve<IShipCollidedUseCase>()
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
                    stageContextReferences.CinemachineVirtualCamera,
                    stageContextReferences.CameraStartingTarget
                    ));

            containerBuilder.Bind<ISetActionInputDetectionUIVisibleUseCase>()
                .FromFunction((c) => new SetActionInputDetectionUIVisibleUseCase(
                    uiViewStackService
                    ));

            containerBuilder.Bind<ISetDirectionSelectorUIVisibleUseCase>()
                .FromFunction(c => new SetDirectionSelectorUIVisibleUseCase(
                    uiViewStackService
                    ));

            containerBuilder.Bind<ISetEffectsUIVisibleUseCase>()
                .FromFunction(c => new SetEffectsUIVisibleUseCase(
                    uiViewStackService
                    ));

            containerBuilder.Bind<ISetupStageUseCase>()
                .FromFunction((c) => new SetupStageUseCase(
                    stageLoadedToken,
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    timeService.UnscaledTimeContext.NewTimer(),
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

            containerBuilder.Bind<IModifyCameraOnceStartsUseCase>()
                .FromFunction((c) => new ModifyCameraOnceStartsUseCase(
                    stageContextReferences.CinemachineVirtualCamera
                    ));

            containerBuilder.Bind<IStartDirectionSelectionUseCase>()
                .FromFunction(c => new StartDirectionSelectionUseCase(
                    c.Resolve<DirectionSelectionValueTickable>()
                    ));

            containerBuilder.Bind<IStartStageUseCase>()
                .FromFunction((c) => new StartStageUseCase(
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<InputState>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISetSectionsTickablesActiveUseCase>(),
                    c.Resolve<IModifyCameraOnceStartsUseCase>(),
                    c.Resolve<IStartShipMovementUseCase>(),
                    c.Resolve<ISetDirectionSelectorUIVisibleUseCase>(),
                    c.Resolve<ISetEffectsUIVisibleUseCase>(),
                    c.Resolve<IStartDirectionSelectionUseCase>()
                    ));

            containerBuilder.Bind<IChangeShipDirectionUseCase>()
                .FromFunction(c => new ChangeShipDirectionUseCase(
                    c.Resolve<InputState>(),
                    c.Resolve<DirectionSelectionState>(),
                    c.Resolve<IDirectionSelectorUIInteractor>()
                    ));

            containerBuilder.Bind<IInputActionReceivedUseCase>()
                .FromFunction((c) => new InputActionReceivedUseCase(
                    eventDispatcher,
                    c.Resolve<IChangeShipDirectionUseCase>()
                    ));

            containerBuilder.Bind<IFinishStageUseCase>()
                .FromFunction(c => new FinishStageUseCase(
                    stageContextReferences.StageSettings,
                    timeService.UnscaledTimeContext.NewTimer(),
                    c.Resolve<ISetActionInputDetectionUIVisibleUseCase>(),
                    c.Resolve<ISetDirectionSelectorUIVisibleUseCase>(),
                    c.Resolve<ISetEffectsUIVisibleUseCase>(),
                    stageFinishedUseCase
                    ));
            
            containerBuilder.Bind<IShipDestroyedUseCase>()
                .FromFunction((c) => new ShipDestroyedUseCase(
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<IStopShipMovementUseCase>(),
                    c.Resolve<IFinishStageUseCase>()
                    ));

            // Effects
            containerBuilder.Bind<IRemoveEffectUseCase>()
                .FromFunction(c => new RemoveEffectUseCase(
                    c.Resolve<IRepository<IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IEffectsUIInteractor>()
                    ));

            containerBuilder.Bind<IAddEffectUseCase>()
                .FromFunction(c => new AddEffectUseCase(
                    c.Resolve<IFactory<EffectConfiguration, IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IRepository<IDisposable<EffectWithTriggerExpirator>>>(),
                    c.Resolve<IEffectsUIInteractor>(),
                    c.Resolve<IRemoveEffectUseCase>()
                    ));

        }
    }
}
