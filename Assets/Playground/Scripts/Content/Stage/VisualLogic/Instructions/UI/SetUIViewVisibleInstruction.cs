using Juce.CoreUnity.UI;
using Playground.Services.ViewStack;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.Instructions
{
    public class SetUIViewVisibleInstruction<T> where T : UIView
    {
        private readonly UIViewStackService uiViewStackService;
        private readonly bool visible;
        private readonly bool instantly;

        public SetUIViewVisibleInstruction(
            UIViewStackService uiViewStackService,
            bool visible,
            bool instantly
            )
        {
            this.uiViewStackService = uiViewStackService;
            this.visible = visible;
            this.instantly = instantly;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            if (visible)
            {
                return uiViewStackService.New().Show<T>(instantly).Execute(cancellationToken);
            }

            return uiViewStackService.New().Hide<T>(instantly).Execute(cancellationToken);
        }
    }
}
