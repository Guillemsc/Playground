using Playground.Content.StageUI.UI.MainStageUI;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible
{
    public class SetMainStageUIVisibleUseCase : ISetMainStageUIVisibleUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SetMainStageUIVisibleUseCase(
            UIViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public Task Execute(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if (!visible)
            {
                return uiViewStackService.New().Hide<MainStageUIView>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Show<MainStageUIView>(instantly).Execute(cancellationToken);
        }
    }
}
