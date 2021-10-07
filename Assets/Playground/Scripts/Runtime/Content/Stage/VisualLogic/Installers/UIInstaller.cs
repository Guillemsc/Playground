using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.DirectionSelector;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public class UIInstaller : IInstaller
    {
        private readonly IActionInputDetectionUIInteractor actionInputDetectionUIInteractor;
        private readonly IDirectionSelectorUIInteractor directionSelectorUIInteractor;

        public UIInstaller(
            IActionInputDetectionUIInteractor actionInputDetectionUIInteractor,
            IDirectionSelectorUIInteractor directionSelectorUIInteractor
            )
        {
            this.actionInputDetectionUIInteractor = actionInputDetectionUIInteractor;
            this.directionSelectorUIInteractor = directionSelectorUIInteractor;
        }

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<IActionInputDetectionUIInteractor>().FromInstance(actionInputDetectionUIInteractor);
            container.Bind<IDirectionSelectorUIInteractor>().FromInstance(directionSelectorUIInteractor);
        }
    }
}
