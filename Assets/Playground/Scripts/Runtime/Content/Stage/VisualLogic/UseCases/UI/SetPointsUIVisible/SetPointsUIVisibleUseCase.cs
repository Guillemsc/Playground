using Playground.Content.StageUI.UI.Points;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetPointsUIVisible
{
    public class SetPointsUIVisibleUseCase : ISetPointsUIVisibleUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SetPointsUIVisibleUseCase(
            UIViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public Task Execute(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if (!visible)
            {
                return uiViewStackService.New().Hide<PointsUIView>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Show<PointsUIView>(instantly).Execute(cancellationToken);
        }
    }
}
