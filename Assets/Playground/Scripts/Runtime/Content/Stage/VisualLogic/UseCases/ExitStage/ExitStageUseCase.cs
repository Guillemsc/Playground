using Juce.Core.Sequencing;
using Juce.CoreUnity.Service;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.VisualLogic.Sequences;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class ExitStageUseCase : IExitStageUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly StopCarAndHideUISequence stopCarAndHideUISequence;

        public ExitStageUseCase(
            Sequencer sequencer,
            TimeService timeService,
            StageOverlayUIView stageOverlayUIView,
            StageViewRepository stageViewRepository,
            StopCarAndHideUISequence stopCarAndHideUISequence
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.stageOverlayUIView = stageOverlayUIView;
            this.stageViewRepository = stageViewRepository;
            this.stopCarAndHideUISequence = stopCarAndHideUISequence;
        }

        public void Execute()
        {
            sequencer.Kill();

            sequencer.Play((ct) => ExecuteSequence(ct));

            sequencer.Enabled = false;
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {
            await stopCarAndHideUISequence.Execute(cancellationToken);

            FlowService flowService = ServicesProvider.GetService<FlowService>();

            ILoadingToken loadingToken = await flowService.FlowUseCases.ShowLoadingScreenFlowUseCase.Execute(instantly: false);

            await flowService.FlowUseCases.BackToMetaFromStageFlowUseCase.Execute(loadingToken);
        }
    }
}
