using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.Core.Repositories;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Tickables;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Sequencing;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.FinishStage;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed;
using Playground.Content.Stage.VisualLogic.UseCases.StartDirectionSelection;
using Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.ViewStack;
using Playground.Content.Stage.VisualLogic.UseCases.ChangeShipDirection;
using Playground.Content.Stage.VisualLogic.UseCases.KillShip;
using Playground.Content.Stage.VisualLogic.UseCases.StartShip;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.GeneratePointGoals;
using Playground.Content.Stage.VisualLogic.UseCases.PointsChanged;
using Playground.Content.StageUI.UI.Points;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalAsCollected;
using Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible;
using Juce.CoreUnity.Time;
using Playground.Services.Persistence;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class UseCasesInstaller : IInstaller
    {
        private readonly ILoadingToken stageLoadedToken;
        private readonly IStageFinishedUseCase stageFinishedUseCase;
        private readonly IEventDispatcher eventDispatcher;
        private readonly TickablesService tickableService;
        private readonly ITimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly PersistenceService persistenceService;
        private readonly StageVisualLogicSetup visualLogicStageSetup;
        private readonly StageContextInstance stageContextReferences;

        public UseCasesInstaller(
            ILoadingToken stageLoadedToken,
            IStageFinishedUseCase stageFinishedUseCase,
            IEventDispatcher eventDispatcher,
            TickablesService tickableService,
            ITimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextInstance stageContextReferences
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
            containerBuilder.InstallState();

            containerBuilder.InstallStats(
                visualLogicStageSetup
                );

            containerBuilder.InstallShip(
                eventDispatcher,
                tickableService,
                timeService,
                visualLogicStageSetup,
                stageContextReferences
                );

            containerBuilder.InstallCamera(
                stageContextReferences
                );

            containerBuilder.InstallEffects(
                tickableService,
                timeService
                );

            containerBuilder.InstallCoins();

            containerBuilder.InstallSections(
                tickableService,
                visualLogicStageSetup,
                stageContextReferences
                );

            containerBuilder.InstallPointGoals(
                tickableService,
                visualLogicStageSetup,
                stageContextReferences
                );

            containerBuilder.InstallDirectionSelector(
                tickableService,
                timeService,
                visualLogicStageSetup
                );

            containerBuilder.InstallToasterTexts();

            containerBuilder.InstallUI(
                uiViewStackService
                );

            containerBuilder.Bind<ISequencerTimelines<StageTimeline>, SequencerTimelines<StageTimeline>>()
                 .FromNew()
                 .WhenDispose((o) => o.KillAll());

            containerBuilder.Bind<ISetupStageUseCase>()
                .FromFunction((c) => new SetupStageUseCase(
                    stageLoadedToken,
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    timeService.UnscaledTimeContext.NewTimer(),
                    c.Resolve<ITryCreateShipViewUseCase>(),
                    c.Resolve<IGenerateSectionsUseCase>(),
                    c.Resolve<IGeneratePointGoalsUseCase>(),
                    c.Resolve<ISetupCameraUseCase>(),
                    c.Resolve<ISetActionInputDetectionUIVisibleUseCase>()
                    ));

            containerBuilder.Bind<IStartStageUseCase>()
                .FromFunction((c) => new StartStageUseCase(
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<InputState>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISetSectionsTickablesActiveUseCase>(),
                    c.Resolve<ISetPointGoalsTickablesActiveUseCase>(),
                    c.Resolve<IModifyCameraOnceStartsUseCase>(),
                    c.Resolve<IStartShipMovementUseCase>(),
                    c.Resolve<IStartShipUseCase>(),
                    c.Resolve<ISetMainStageUIVisibleUseCase>(),
                    c.Resolve<IStartDirectionSelectionUseCase>()
                    ));

            containerBuilder.Bind<IInputActionReceivedUseCase>()
                .FromFunction((c) => new InputActionReceivedUseCase(
                    eventDispatcher,
                    c.Resolve<IChangeShipDirectionUseCase>()
                    ));

            containerBuilder.Bind<IChangeShipDirectionUseCase>()
                .FromFunction(c => new ChangeShipDirectionUseCase(
                    c.Resolve<InputState>(),
                    c.Resolve<DirectionSelectionState>(),
                    c.Resolve<IDirectionSelectorUIInteractor>()
                    ));

            containerBuilder.Bind<IFinishStageUseCase>()
                .FromFunction(c => new FinishStageUseCase(
                    stageContextReferences.StageSettings,
                    timeService.UnscaledTimeContext.NewTimer(),
                    c.Resolve<PointsState>(),
                    c.Resolve<ISetActionInputDetectionUIVisibleUseCase>(),
                    c.Resolve<ISetMainStageUIVisibleUseCase>(),
                    stageFinishedUseCase
                    ));
            
            containerBuilder.Bind<IShipDestroyedUseCase>()
                .FromFunction((c) => new ShipDestroyedUseCase(
                    c.Resolve<ISequencerTimelines<StageTimeline>>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IStopShipMovementUseCase>(),
                    c.Resolve<IKillShipUseCase>(),
                    c.Resolve<IFinishStageUseCase>()
                    ));

            containerBuilder.Bind<IPointsChangedUseCase>()
                .FromFunction(c => new PointsChangedUseCase(
                    c.Resolve<ISequencerTimelines <StageTimeline>>(),
                    c.Resolve<PointsState>(),
                    c.Resolve<IPointsUIInteractor>(),
                    c.Resolve<ISetPointGoalAsCollectedUseCase>()
                    ));

        }
    }
}
