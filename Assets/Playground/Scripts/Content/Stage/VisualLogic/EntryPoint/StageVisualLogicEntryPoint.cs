using Cinemachine;
using Juce.Core.Events;
using Juce.Core.Sequencing;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.UseCases;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Services;
using System;
using UnityEngine.EventSystems;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        private readonly ILoadingToken loadingToken;
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventReceiver eventReceiver;
        private readonly TimeService timeService;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly StageView stageViewPrefab;
        private readonly CarLibrary carLibrary;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;

        public StageVisualLogicEntryPoint(
            ILoadingToken loadingToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TimeService timeService,
            StageOverlayUIView stageOverlayUIView,
            StageCompletedUIView stageCompletedUIView,
            StageView stageViewPrefab,
            CarLibrary carLibrary,
            CinemachineVirtualCamera followCarVirtualCamera
            )
        {
            this.loadingToken = loadingToken;
            this.eventDispatcher = eventDispatcher;
            this.eventReceiver = eventReceiver;
            this.timeService = timeService;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageCompletedUIView = stageCompletedUIView;
            this.stageViewPrefab = stageViewPrefab;
            this.carLibrary = carLibrary;
            this.followCarVirtualCamera = followCarVirtualCamera;

            Sequencer sequencer = new Sequencer();

            StageViewRepository stageViewRepository = new StageViewRepository();
            CarViewRepository carViewRepository = new CarViewRepository();

            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal = new GenericSignal<CheckPointsView, CheckPointView>();
            GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal = new GenericSignal<FinishLineView, EventArgs>();

            UseCasesRepository useCasesRepository = new UseCasesRepository(
                new LoadStageUseCase(
                    sequencer,
                    timeService,
                    stageOverlayUIView,
                    stageViewRepository,
                    stageViewPrefab,
                    carLibrary,
                    carViewRepository,
                    checkPointCrossedSignal,
                    finishLineCrossedSignal,
                    followCarVirtualCamera,
                    loadingToken
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
                            stageCompletedUIView,
                            stageViewRepository,
                            carViewRepository
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
                     carViewRepository
                    )
                );

            eventReceiver.Subscribe((LoadStageOutEvent ev) =>
            {
                useCasesRepository.LoadStageUseCase.Execute();
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

            stageOverlayUIView.OnRestartClicked += (StageOverlayUIView stageOverlayUIView, PointerEventData pointerEventData) =>
            {
                useCasesRepository.RestartStageUseCase.Execute();
            };
        }
    }
}
