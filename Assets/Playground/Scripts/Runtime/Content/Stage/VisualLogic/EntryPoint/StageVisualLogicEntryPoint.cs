using Juce.Core.CleanUp;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Installers;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.InputActionReceived;
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

        private IDIContainer container;

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

            containerBuilder.Bind(new UseCasesInstaller(
                stageLoadedToken,
                eventDispatcher,
                tickableService,
                timeService,
                uiViewStackService,
                persistenceService,
                visualLogicStageSetup,
                stageContextReferences
                ));

            container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            ISetupStageUseCase setupStageUseCase = container.Resolve<ISetupStageUseCase>();
            IStartStageUseCase startStageUseCase = container.Resolve<IStartStageUseCase>();
            IInputActionReceivedUseCase inputActionReceivedUseCase = container.Resolve<IInputActionReceivedUseCase>();

            ActionInputDetectionUIInteractor actionInputDetectionUIInteractor = uiViewStackService.GetInteractor<ActionInputDetectionUIInteractor>();

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
