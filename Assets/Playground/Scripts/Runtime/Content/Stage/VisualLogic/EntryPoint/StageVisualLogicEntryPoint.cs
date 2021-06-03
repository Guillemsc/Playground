using Cinemachine;
using Juce.Core.CleanUp;
using Juce.Core.Events;
using Juce.Core.Sequencing;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.Services;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Sequences;
using Playground.Content.Stage.VisualLogic.Tickable;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.ScreenCarControls;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Content.StageUI.UI.StageSettings;
using Playground.Services;
using Playground.Services.ViewStack;
using System;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private readonly ILoadingToken loadingToken;
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;
        private readonly TickablesService tickableService;
        private readonly TimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly ScreenCarControlsUIView screenCarControlsUIView;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly StageView stageViewPrefab;
        private readonly CarLibrary carLibrary;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;
        private readonly ICleanUpActionsRepository cleanUpActionsRepository;

        public StageVisualLogicEntryPoint(
            ILoadingToken loadingToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            ScreenCarControlsUIView screenCarControlsUIView,
            StageOverlayUIView stageOverlayUIView,
            StageCompletedUIView stageCompletedUIView,
            StageView stageViewPrefab,
            CarLibrary carLibrary,
            CinemachineVirtualCamera followCarVirtualCamera,
            ICleanUpActionsRepository cleanUpActionsRepository
            )
        {
            this.loadingToken = loadingToken;
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;
            this.tickableService = tickableService;
            this.timeService = timeService;
            this.uiViewStackService = uiViewStackService;
            this.screenCarControlsUIView = screenCarControlsUIView;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageCompletedUIView = stageCompletedUIView;
            this.stageViewPrefab = stageViewPrefab;
            this.carLibrary = carLibrary;
            this.followCarVirtualCamera = followCarVirtualCamera;
            this.cleanUpActionsRepository = cleanUpActionsRepository;

            Sequencer sequencer = new Sequencer();

            StageViewRepository stageViewRepository = new StageViewRepository();
            CarViewRepository carViewRepository = new CarViewRepository();

            StageTimerState stageTimerState = new StageTimerState(timeService.ScaledTimeContext.NewTimer());

            CarControllerSignals carControllerSignals = new CarControllerSignals();
            CarViewControllerSignals carViewControllerSignals = new CarViewControllerSignals();

            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal = new GenericSignal<CheckPointsView, CheckPointView>();
            GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal = new GenericSignal<FinishLineView, EventArgs>();

            StageOverlayUIInteractor stageOverlayUIInteractor = uiViewStackService.GetInteractor<StageOverlayUIInteractor>();
            StageSettingsUIInteractor stageSettingsUIInteractor = uiViewStackService.GetInteractor<StageSettingsUIInteractor>();

            UpdateStageTimerTickable updateStageTimerTickable = new UpdateStageTimerTickable(
                stageOverlayUIInteractor,
                stageTimerState
                );
            tickableService.AddTickable(updateStageTimerTickable);
            cleanUpActionsRepository.Add(() => tickableService.RemoveTickable(updateStageTimerTickable));

            StopCarAndHideUISequence stopCarAndHideUISequence = new StopCarAndHideUISequence(
                uiViewStackService,
                stageOverlayUIView,
                carViewRepository
                );

            UseCasesRepository useCasesRepository = new UseCasesRepository(
                new LoadStageUseCase(
                    sequencer,
                    timeService,
                    uiViewStackService,
                    screenCarControlsUIView,
                    stageOverlayUIView,
                    stageViewRepository,
                    stageViewPrefab,
                    carLibrary,
                    carViewRepository,
                    carControllerSignals,
                    carViewControllerSignals,
                    checkPointCrossedSignal,
                    finishLineCrossedSignal,
                    followCarVirtualCamera,
                    loadingToken
                    ),

                new StartStageUseCase(
                    stageTimerState
                    ),

                new CarAcceleratesOrBrakesUseCase(
                    eventDispatcher
                    ),

                new CheckPointCrossedUseCase(
                    eventDispatcher
                    ),

                new FinishLineCrossedUseCase(
                    eventDispatcher
                    ),

                new CurrentCheckPointChangedUseCase(
                    sequencer,
                    stageViewRepository
                    ),

                new NextCheckPointChangedUseCase(
                    sequencer,
                    stageViewRepository
                    ),

                new CompositeStageFinishedUseCase(
                    new IStageFinishedUseCase[]
                    {
                        new StopAndShowUIStageFinishedUseCase(
                            sequencer,
                            timeService,
                            uiViewStackService,
                            stageCompletedUIView,
                            stageViewRepository,
                            stageTimerState,
                            stopCarAndHideUISequence
                            ),

                        new UnloadStageStageFinishedUseCase(
                            sequencer,
                            timeService,
                            stageCompletedUIView,
                            stageViewRepository,
                            carViewRepository
                            )
                    }),

                new RestartStageUseCase(
                    sequencer,
                    timeService,
                    stageOverlayUIView,
                    stageViewRepository,
                    stopCarAndHideUISequence
                    ),

                new ExitStageUseCase(
                    sequencer,
                    timeService,
                    stageOverlayUIView,
                    stageViewRepository,
                    stopCarAndHideUISequence
                    )
                );

            eventReceiver.Subscribe((LoadStageOutEvent ev) =>
            {
                useCasesRepository.LoadStageUseCase.Execute();
            });

            eventReceiver.Subscribe((StartStageOutEvent ev) =>
            {
                useCasesRepository.StartStageUseCase.Execute();
            });

            eventReceiver.Subscribe((CurrentCheckPointChangedOutEvent ev) =>
            {
                useCasesRepository.CurrentCheckPointChangedUseCase.Execute(ev.CheckPointIndex);
            });

            eventReceiver.Subscribe((NextCheckPointChangedOutEvent ev) =>
            {
                useCasesRepository.NextCheckPointChangedUseCase.Execute(ev.CheckPointIndex);
            });

            eventReceiver.Subscribe((StageFinishedOutEvent ev) =>
            {
                useCasesRepository.StageFinishedUseCase.Execute();
            });

            checkPointCrossedSignal.OnTrigger += (CheckPointsView checkPointsView, CheckPointView checkPointView) =>
            {
                useCasesRepository.CheckPointCrossedUseCase.Execute(checkPointView);
            };

            finishLineCrossedSignal.OnTrigger += (FinishLineView finishLineView, EventArgs eventArgs) =>
            {
                useCasesRepository.FinishLineCrossedUseCase.Execute(finishLineView);
            };

            screenCarControlsUIView.OnLeftPointerCallbacksDown += (ScreenCarControlsUIView screenCarControlsUIView, PointerCallbacks pointerCallbacks) =>
            {
                carControllerSignals.LeftSignal.Trigger(carControllerSignals, EventArgs.Empty);
            };

            screenCarControlsUIView.OnRightPointerCallbacksDown += (ScreenCarControlsUIView screenCarControlsUIView, PointerCallbacks pointerCallbacks) =>
            {
                carControllerSignals.RightSignal.Trigger(carControllerSignals, EventArgs.Empty);
            };

            screenCarControlsUIView.OnAcceleratePointerCallbacksDown += (ScreenCarControlsUIView screenCarControlsUIView, PointerCallbacks pointerCallbacks) =>
            {
                carControllerSignals.AccelerateSignal.Trigger(carControllerSignals, EventArgs.Empty);
            };

            screenCarControlsUIView.OnBreakPointerCallbacksDown += (ScreenCarControlsUIView screenCarControlsUIView, PointerCallbacks pointerCallbacks) =>
            {
                carControllerSignals.BreakSignal.Trigger(carControllerSignals, EventArgs.Empty);
            };

            carViewControllerSignals.AcceleratesOrBrakesSignal.OnTrigger += (CarViewControllerSignals carViewControllerSignals, EventArgs eventArgs) =>
            {
                useCasesRepository.CarAcceleratesOrBrakesUseCase.Execute();
            };

            stageOverlayUIInteractor.RegisterRestartCallback(() =>
            {
                useCasesRepository.RestartStageUseCase.Execute();
            });

            stageSettingsUIInteractor.RegisterExitStageCallback(() =>
            {
                useCasesRepository.ExitStageUseCase.Execute();
            });
        }
    }
}
