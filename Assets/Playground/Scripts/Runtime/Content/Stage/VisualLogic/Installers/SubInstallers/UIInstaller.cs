using Juce.Core.DI.Builder;
using Playground.Content.Stage.VisualLogic.UseCases.SetDirectionSelectorUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetEffectsUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetMainStageUIVisible;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointsUIVisible;
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

            container.Bind<ISetMainStageUIVisibleUseCase>()
                .FromFunction(c => new SetMainStageUIVisibleUseCase(
                    uiViewStackService
                    ));
        }
    }
}
