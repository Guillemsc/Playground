using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible
{
    public class SetDirectionSelectorUIVisibleUseCase : ISetDirectionSelectorUIVisibleUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SetDirectionSelectorUIVisibleUseCase(
            UIViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public Task Execute(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if (!visible)
            {
                return uiViewStackService.New().Hide<DirectionSelectorUIView>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Show<DirectionSelectorUIView>(instantly).Execute(cancellationToken);
        }
    }
}
