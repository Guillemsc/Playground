using Playground.Content.StageUI.UI.Effects;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible
{
    public class SetEffectsUIVisibleUseCase : ISetEffectsUIVisibleUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SetEffectsUIVisibleUseCase(
            UIViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public Task Execute(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if (!visible)
            {
                return uiViewStackService.New().Hide<EffectsUIView>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Show<EffectsUIView>(instantly).Execute(cancellationToken);
        }
    }
}
