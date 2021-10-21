using Juce.Core.DI.Builder;
using Playground.Content.Stage.VisualLogic.UseCases.PlayToasterText;
using Playground.Content.StageUI.UI.ToasterTexts;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class ToasterTextsInstaller
    {
        public static void InstallToasterTexts(
            this IDIContainerBuilder container
            )
        {
            container.Bind<IPlayToasterTextUseCase>()
                .FromFunction(c => new PlayToasterTextUseCase(
                    c.Resolve<IToasterTextsUIInteractor>()
                    ));
        }
    }
}
