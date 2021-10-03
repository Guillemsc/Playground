using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.SetupCamera
{
    public class SetActionInputDetectionUIVisibleUseCase : ISetActionInputDetectionUIVisibleUseCase
    {
        private readonly UIViewStackService uiViewStackService;

        public SetActionInputDetectionUIVisibleUseCase(
            UIViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public Task Execute(bool visible, bool instantly, CancellationToken cancellationToken)
        {
            if(!visible)
            {
                return uiViewStackService.New().Hide<ActionInputDetectionUIView>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Show<ActionInputDetectionUIView>(instantly).Execute(cancellationToken);
        }
    }
}
