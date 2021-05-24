using Cinemachine;
using Juce.Core.Sequencing;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly StageView stageViewPrefab;
        private readonly CarLibrary carLibrary;
        private readonly CarViewRepository carViewRepository;
        private readonly GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal;
        private readonly GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;
        private readonly ILoadingToken loadingToken;

        public LoadStageUseCase(
            Sequencer sequencer,
            TimeService timeService,
            StageOverlayUIView stageOverlayUIView,
            StageViewRepository stageViewRepository,
            StageView stageViewPrefab,
            CarLibrary carLibrary,
            CarViewRepository carViewRepository,
            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal,
            GenericSignal<FinishLineView, EventArgs> finishLineCrossedSignal,
            CinemachineVirtualCamera followCarVirtualCamera,
            ILoadingToken loadingToken
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageViewRepository = stageViewRepository;
            this.stageViewPrefab = stageViewPrefab;
            this.carLibrary = carLibrary;
            this.carViewRepository = carViewRepository;
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
            new LoadStageInstruction(stageViewRepository, stageViewPrefab).Execute();
            new LoadCarInstruction(carLibrary, carViewRepository).Execute();

            StageView stageView = stageViewRepository.StageView;
            CarView carView = carViewRepository.CarView;

            new RegisterCheckPointsSignalsInstruction(stageView.CheckPointsView, checkPointCrossedSignal).Execute();
            new SetCheckPointAsActive(stageView.CheckPointsView, checkPointIndex: 0).Execute();

            new RegisterFinishLineSignalsInstruction(stageView.FinishLineView, finishLineCrossedSignal).Execute();

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.AutoBreak).Execute();

            new TeleportCarToTransformInstruction(carViewRepository, stageViewPrefab.CarStartPosition).Execute();
            new AttachCameraToCarInstruction(carViewRepository, followCarVirtualCamera).Execute();

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            new SetLoadingTokenAsCompletedInstruction(loadingToken).Execute();

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(0.5f)).Execute(cancellationToken);

            await new SetStageOverlayVisibleInstruction(stageOverlayUIView, visible: true, instantly: false).Execute(cancellationToken);

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.FullMovement).Execute();
        }
    }
}
