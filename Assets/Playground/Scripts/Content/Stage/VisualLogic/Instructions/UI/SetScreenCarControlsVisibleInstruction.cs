using Playground.Content.StageUI.UI.ScreenCarControls;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetScreenCarControlsVisibleInstruction
    {
        private readonly ScreenCarControlsUIView screenCarControlsUIView;
        private readonly bool visible;
        private readonly bool instantly;

        public SetScreenCarControlsVisibleInstruction(
            ScreenCarControlsUIView screenCarControlsUIView,
            bool visible,
            bool instantly
            )
        {
            this.screenCarControlsUIView = screenCarControlsUIView;
            this.visible = visible;
            this.instantly = instantly;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            if (visible)
            {
                return screenCarControlsUIView.Show(instantly, cancellationToken);
            }

            return screenCarControlsUIView.Hide(instantly, cancellationToken);
        }
    }
}
