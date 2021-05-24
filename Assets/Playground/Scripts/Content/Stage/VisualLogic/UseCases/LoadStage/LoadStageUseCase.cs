using Cinemachine;
using Juce.Core.Sequencing;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
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
        private readonly CarLibrary carLibrary;
        private readonly CarViewRepository carViewRepository;
        private readonly StageViewRepository stageViewRepository;
        private readonly StageView stageViewPrefab;
        private readonly GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal;
        private readonly CinemachineVirtualCamera followCarVirtualCamera;
        private readonly ILoadingToken loadingToken;

        public LoadStageUseCase(
            Sequencer sequencer,
            TimeService timeService,
            CarLibrary carLibrary,
            CarViewRepository carViewRepository,
            StageViewRepository stageViewRepository,
            StageView stageViewPrefab,
            GenericSignal<CheckPointsView, CheckPointView> checkPointCrossedSignal,
            CinemachineVirtualCamera followCarVirtualCamera,
            ILoadingToken loadingToken
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.carLibrary = carLibrary;
            this.carViewRepository = carViewRepository;
            this.stageViewRepository = stageViewRepository;
            this.stageViewPrefab = stageViewPrefab;
            this.checkPointCrossedSignal = checkPointCrossedSignal;
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

            StageView stageView = stageViewRepository.StageView;

            new RegisterCheckPointsSignalsInstruction(stageView.CheckPointsView, checkPointCrossedSignal).Execute();
            new SetCheckPointAsActive(stageView.CheckPointsView, checkPointIndex: 0).Execute();

            new LoadCarInstruction(carLibrary, carViewRepository).Execute();

            new TeleportCarToTransformInstruction(carViewRepository, stageViewPrefab.CarStartPosition).Execute();
            new AttachCameraToCarInstruction(carViewRepository, followCarVirtualCamera).Execute();

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            new SetLoadingTokenAsCompletedInstruction(loadingToken).Execute();
        }
    }
}
