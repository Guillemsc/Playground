using Juce.Core.CleanUp;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Time;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.UseCases.StageFinished;
using Playground.Content.Stage.VisualLogic.Cheats;
using Playground.Content.Stage.VisualLogic.Installers;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.CoinsChanged;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
using Playground.Content.Stage.VisualLogic.UseCases.PointsChanged;
using Playground.Content.Stage.VisualLogic.UseCases.SetupStage;
using Playground.Content.Stage.VisualLogic.UseCases.ShipDestroyed;
using Playground.Content.Stage.VisualLogic.UseCases.StartStage;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Contexts.Stage;
using Playground.Services;
using Playground.Services.Persistence;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private readonly ICleanUpActionsRepository cleanUpActionsRepository = new CleanUpActionsRepository();

        private IDIContainer container;

        public StageVisualLogicCheats StageVisualLogicCheats { get; }

        public StageVisualLogicEntryPoint(
            ILoadingToken stageLoadedToken,
            IStageFinishedUseCase stageFinishedUseCase,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TickablesService tickableService,
            ITimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextInstance stageContextReferences,
            IDIContainer stageUiContainer
            )
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind(stageUiContainer);

            containerBuilder.Bind(new UseCasesInstaller(
                stageLoadedToken,
                stageFinishedUseCase,
                eventDispatcher,
                tickableService,
                timeService,
                uiViewStackService,
                persistenceService,
                visualLogicStageSetup,
                stageContextReferences
                ));

            containerBuilder.Bind(new CheatsInstaller());

            container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            StageVisualLogicCheats = container.Resolve<StageVisualLogicCheats>();

            ISetupStageUseCase setupStageUseCase = container.Resolve<ISetupStageUseCase>();
            IStartStageUseCase startStageUseCase = container.Resolve<IStartStageUseCase>();
            IInputActionReceivedUseCase inputActionReceivedUseCase = container.Resolve<IInputActionReceivedUseCase>();
            IShipDestroyedUseCase shipDestroyedUseCase = container.Resolve<IShipDestroyedUseCase>();
            IPointsChangedUseCase pointsChangedUseCase = container.Resolve<IPointsChangedUseCase>();
            ICoinsChangedUseCase coinsChangedUseCase = container.Resolve<ICoinsChangedUseCase>();

            IActionInputDetectionUIInteractor actionInputDetectionUIInteractor = container.Resolve<IActionInputDetectionUIInteractor>();

            eventReceiver.Subscribe((SetupStageOutEvent setupStageOutEvent) =>
            {
                setupStageUseCase.Execute(
                    setupStageOutEvent.ShipEntitySnapshot
                    );
            });

            eventReceiver.Subscribe((StartStageOutEvent startStageOutEvent) =>
            {
                startStageUseCase.Execute(
                    startStageOutEvent.ShipEntitySnapshot
                    );
            });

            eventReceiver.Subscribe((ShipDestroyedOutEvent shipDestroyedOutEvent) =>
            {
                shipDestroyedUseCase.Execute();
            });

            eventReceiver.Subscribe((PointsChangedOutEvent pointsChangedOutEvent) =>
            {
                pointsChangedUseCase.Execute(pointsChangedOutEvent.CurrentPoints);
            });

            eventReceiver.Subscribe((CoinsChangedOutEvent coinsChangedOutEvent) =>
            {
                coinsChangedUseCase.Execute(coinsChangedOutEvent.CurrentCoins);
            });

            actionInputDetectionUIInteractor.InputActionReceived += (
                ActionInputDetectionUIInteractor actionInputDetectionUIInteractor,
                EventArgs eventArgs
                ) =>
            {
                inputActionReceivedUseCase.Execute();
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
