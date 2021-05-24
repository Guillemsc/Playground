using Juce.Core.Sequencing;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class RestartStageUseCase : IRestartStageUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly CarViewRepository carViewRepository;

        public RestartStageUseCase(
            Sequencer sequencer,
            TimeService timeService,
            StageOverlayUIView stageOverlayUIView,
            StageViewRepository stageViewRepository,
            CarViewRepository carViewRepository
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageViewRepository = stageViewRepository;
            this.carViewRepository = carViewRepository;
        }

        public void Execute()
        {
            sequencer.Kill();

            sequencer.Play((ct) => ExecuteSequence(ct));

            sequencer.Enabled = false;
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {
            StageView stageView = stageViewRepository.StageView;
            CarView carView = carViewRepository.CarView;

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.AutoBreak).Execute();

            await new SetStageOverlayVisibleInstruction(stageOverlayUIView, visible: true, instantly: false).Execute(cancellationToken);

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            FlowService flowService = ServicesProvider.GetService<FlowService>();

            ILoadingToken loadingToken = await flowService.FlowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: false);

            await flowService.FlowUseCases.ReplayScenarioFlowUseCase.Execute(loadingToken);
        }
    }
}
