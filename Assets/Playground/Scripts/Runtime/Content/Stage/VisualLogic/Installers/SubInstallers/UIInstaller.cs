using Juce.Core.DI.Builder;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Services.ViewStack;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class UIInstaller
    {
        public static void InstallUI(
            this IDIContainerBuilder container,
            UIViewStackService uiViewStackService
            )
        {
            container.Bind<ISetActionInputDetectionUIVisibleUseCase>()
                .FromFunction((c) => new SetActionInputDetectionUIVisibleUseCase(
                    uiViewStackService
                    ));

            container.Bind<ISetDirectionSelectorUIVisibleUseCase>()
                .FromFunction(c => new SetDirectionSelectorUIVisibleUseCase(
                    uiViewStackService
                    ));

            container.Bind<ISetEffectsUIVisibleUseCase>()
                .FromFunction(c => new SetEffectsUIVisibleUseCase(
                    uiViewStackService
                    ));
        }
    }
}
