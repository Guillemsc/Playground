using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class UnloadStageStageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly CarViewRepository carViewRepository;

        public UnloadStageStageFinishedUseCase(
            Sequencer sequencer,
            TimeService timeService,
            StageCompletedUIView stageCompletedUIView,
            StageViewRepository stageViewRepository,
            CarViewRepository carViewRepository
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.stageCompletedUIView = stageCompletedUIView;
            this.stageViewRepository = stageViewRepository;
            this.carViewRepository = carViewRepository;
        }

        public void Execute()
        {
            sequencer.Play((ct) => ExecuteSequence(ct));
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {

        }
    }
}
