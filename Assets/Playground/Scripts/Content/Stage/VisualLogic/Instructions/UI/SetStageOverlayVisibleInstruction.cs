using Playground.Content.StageUI.UI.StageOverlay;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetStageOverlayVisibleInstruction
    {
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly bool visible;
        private readonly bool instantly;

        public SetStageOverlayVisibleInstruction(
            StageOverlayUIView stageOverlayUIView,
            bool visible,
            bool instantly
            )
        {
            this.stageOverlayUIView = stageOverlayUIView;
            this.visible = visible;
            this.instantly = instantly;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            if(visible)
            {
                return stageOverlayUIView.Show(instantly, cancellationToken);
            }

            return stageOverlayUIView.Hide(instantly, cancellationToken);
        }
    }
}
