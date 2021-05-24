using Playground.Content.Stage.VisualLogic.View.Signals;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Content.StageUI.UI.StageCompleted;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class ShowStageCompletedUIInstruction
    {
        private readonly StageCompletedUIView stageCompletedUIView;
        private readonly GenericSignal<StageCompletedUIView, EventArgs> canUnloadStageSignal;

        public ShowStageCompletedUIInstruction(
            StageCompletedUIView stageCompletedUIView,
            GenericSignal<StageCompletedUIView, EventArgs> canUnloadStageSignal
            )
        {
            this.stageCompletedUIView = stageCompletedUIView;
            this.canUnloadStageSignal = canUnloadStageSignal;
        }

        public Task Execute(bool instantly, CancellationToken cancellationToken)
        {
            stageCompletedUIView.Init(canUnloadStageSignal);

            return stageCompletedUIView.Show(instantly, cancellationToken);
        }
    }
}
