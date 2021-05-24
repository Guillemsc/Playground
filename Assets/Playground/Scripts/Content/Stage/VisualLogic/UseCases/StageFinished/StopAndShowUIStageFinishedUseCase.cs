using Juce.Core.Sequencing;
using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.Sequences;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class StopAndShowUIStageFinishedUseCase : IStageFinishedUseCase
    {
        private readonly Sequencer sequencer;
        private readonly TimeService timeService;
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly StageViewRepository stageViewRepository;
        private readonly StopCarAndHideUISequence stopCarAndHideUISequence;

        private TaskCompletionSource<object> taskCompletitionSource = new TaskCompletionSource<object>();

        public StopAndShowUIStageFinishedUseCase(
            Sequencer sequencer,
            TimeService timeService,
            StageCompletedUIView stageCompletedUIView,
            StageViewRepository stageViewRepository,
            StopCarAndHideUISequence stopCarAndHideUISequence
            )
        {
            this.sequencer = sequencer;
            this.timeService = timeService;
            this.stageCompletedUIView = stageCompletedUIView;
            this.stageViewRepository = stageViewRepository;
            this.stopCarAndHideUISequence = stopCarAndHideUISequence;
        }

        public void Execute()
        {
            sequencer.Play((ct) => ExecuteSequence(ct));
        }

        private async Task ExecuteSequence(CancellationToken cancellationToken)
        {
            StageView stageView = stageViewRepository.StageView;

            await stopCarAndHideUISequence.Execute(cancellationToken);

            await new WaitTimeInstruction(timeService.UnscaledTimeContext, TimeSpan.FromSeconds(1.0f)).Execute(cancellationToken);

            GenericSignal<StageCompletedUIView, EventArgs> canUnloadStageSignal = new GenericSignal<StageCompletedUIView, EventArgs>();

            canUnloadStageSignal.OnTrigger += OnCanUnloadStageSignalTriggered;

            await new ShowStageCompletedUIInstruction(
                stageCompletedUIView,
                canUnloadStageSignal
                ).Execute(instantly: false, cancellationToken);

            await taskCompletitionSource.Task;

            canUnloadStageSignal.OnTrigger -= OnCanUnloadStageSignalTriggered;
        }

        private void OnCanUnloadStageSignalTriggered(
            StageCompletedUIView stageCompletedUIView,
            EventArgs eventArgs
            )
        {
            taskCompletitionSource.SetResult(null);
        }
    }
}
