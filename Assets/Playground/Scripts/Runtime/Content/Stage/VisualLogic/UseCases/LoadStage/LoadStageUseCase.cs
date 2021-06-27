using Cinemachine;
using Juce.Core.Sequencing;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.ScreenCarControls;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Libraries.Car;
using Playground.Services;
using Playground.Services.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly UIViewStackService uiViewStackService;
        private readonly ScreenCarControlsUIView screenCarControlsUIView;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly StageView stageView;
        private readonly CarLibrary carLibrary;
        private readonly string carTypeId;
        private readonly CarViewRepository carViewRepository;
        private readonly CarControllerSignals carControllerSignals;
        private readonly CarViewControllerSignals carViewControllerSignals;
        private readonly GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal;
        private readonly GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;
        private readonly ILoadingToken loadingToken;

        public LoadStageUseCase(
            Sequencer sequencer,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            ScreenCarControlsUIView screenCarControlsUIView,
            StageOverlayUIView stageOverlayUIView,
            StageViewRepository stageViewRepository,
            StageView stageView,
            CarLibrary carLibrary,
            string carTypeId,
            CarViewRepository carViewRepository,
            CarControllerSignals carControllerSignals,
            CarViewControllerSignals carViewControllerSignals,
            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal,
            GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal,
            CinemachineVirtualCamera followCarVirtualCamera,
            ILoadingToken loadingToken
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.uiViewStackService = uiViewStackService;
            this.screenCarControlsUIView = screenCarControlsUIView;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageViewRepository = stageViewRepository;
            this.stageView = stageView;
            this.carLibrary = carLibrary;
            this.carTypeId = carTypeId;
            this.carViewRepository = carViewRepository;
            this.carControllerSignals = carControllerSignals;
            this.carViewControllerSignals = carViewControllerSignals;
            this.checkPointCrossedSignal = checkPointCrossedSignal;
            this.finishLineCrossedSignal = finishLineCrossedSignal;
            this.followCarVirtualCamera = followCarVirtualCamera;
            this.loadingToken = loadingToken;
        }

        public void Execute()
        {
            sequencer.Play((ct) => ExecuteSequence(ct));
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {
            stageViewRepository.StageView = stageView;

            new LoadCarInstruction(carLibrary, carViewRepository).Execute(carTypeId);
            CarView carView = carViewRepository.Item;

            new RegisterCheckPointsSignalsInstruction(stageView.CheckPointsView, checkPointCrossedSignal).Execute();
            new SetCheckPointAsActive(stageView.CheckPointsView, checkPointIndex: 0).Execute();

            new RegisterFinishLineSignalsInstruction(stageView.FinishLineView, finishLineCrossedSignal).Execute();

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.AutoHandBrake).Execute();
            new BindCarControllerSignalsInstruction(carControllerSignals, carView.CarViewController).Execute();
            new BindCarViewControllerSignalsInstruction(carViewControllerSignals, carView.CarViewController).Execute();

            new TeleportCarToTransformInstruction(carViewRepository, stageView.CarStartPosition).Execute();
            new AttachCameraToCarInstruction(carViewRepository, followCarVirtualCamera, stageView.CinemachinePath).Execute();

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(0.5f)).Execute(cancellationToken);

            new SetLoadingTokenAsCompletedInstruction(loadingToken).Execute();

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(0.5f)).Execute(cancellationToken);

            await ShowUI(cancellationToken);

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.FullMovement).Execute();
        }

        private Task ShowUI(CancellationToken cancellationToken)
        {
            return Task.WhenAll(
                new SetUIViewVisibleInstruction<ScreenCarControlsUIView>(uiViewStackService, visible: true, instantly: false).Execute(cancellationToken),
                new SetUIViewVisibleInstruction<StageOverlayUIView>(uiViewStackService, visible: true, instantly: false).Execute(cancellationToken)
                );
        }
    }
}
