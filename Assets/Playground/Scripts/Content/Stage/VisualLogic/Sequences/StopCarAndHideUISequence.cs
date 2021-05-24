using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.StageUI.UI.ScreenCarControls;
using Playground.Content.StageUI.UI.StageOverlay;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Sequences
{
    public class StopCarAndHideUISequence
    {
        private readonly ScreenCarControlsUIView screenCarControlsUIView;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly CarViewRepository carViewRepository;

        public StopCarAndHideUISequence(
            ScreenCarControlsUIView screenCarControlsUIView,
            StageOverlayUIView stageOverlayUIView,
            CarViewRepository carViewRepository
            )
        {
            this.screenCarControlsUIView = screenCarControlsUIView;
            this.stageOverlayUIView = stageOverlayUIView;
            this.carViewRepository = carViewRepository;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            CarView carView = carViewRepository.CarView;

            new SetCarViewControllerStateInstruction(carView.CarViewController, CarViewControllerState.AutoBreak).Execute();

            await HideUI(cancellationToken);
        }

        private Task HideUI(CancellationToken cancellationToken)
        {
            return Task.WhenAll(
                new SetScreenCarControlsVisibleInstruction(screenCarControlsUIView, visible: false, instantly: false).Execute(cancellationToken),
                new SetStageOverlayVisibleInstruction(stageOverlayUIView, visible: false, instantly: false).Execute(cancellationToken)
                );
        }
    }
}
