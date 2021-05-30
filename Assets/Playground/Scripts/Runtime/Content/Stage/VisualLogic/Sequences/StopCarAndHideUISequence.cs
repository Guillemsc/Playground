using Playground.Content.Stage.VisualLogic.Instructions;
using Playground.Content.Stage.VisualLogic.View.Car;
using Playground.Content.StageUI.UI.ScreenCarControls;
using Playground.Content.StageUI.UI.StageOverlay;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Sequences
{
    public class StopCarAndHideUISequence
    {
        private readonly UIViewStackService uiViewStackService;
        private readonly StageOverlayUIView stageOverlayUIView;
        private readonly CarViewRepository carViewRepository;

        public StopCarAndHideUISequence(
            UIViewStackService uiViewStackService,
            StageOverlayUIView stageOverlayUIView,
            CarViewRepository carViewRepository
            )
        {
            this.uiViewStackService = uiViewStackService;
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
                new SetUIViewVisibleInstruction<ScreenCarControlsUIView>(uiViewStackService, visible: false, instantly: false).Execute(cancellationToken),
                new SetUIViewVisibleInstruction<StageOverlayUIView>(uiViewStackService, visible: false, instantly: false).Execute(cancellationToken)
                );
        }
    }
}
