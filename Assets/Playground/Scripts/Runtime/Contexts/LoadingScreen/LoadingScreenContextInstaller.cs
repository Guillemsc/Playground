using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Playground.Contexts.LoadingScreen.UseCases.Show;

namespace Playground.Contexts.LoadingScreen
{
    public static class LoadingScreenContextInstaller
    {
        public static IDIContainer Install(
            LoadingScreenContextInstance loadingScreenContextInstance
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind<IShowUseCase>()
                .FromFunction(c => new ShowUseCase(
                    loadingScreenContextInstance.LoadingScreenUIView
                    ));

            container.Bind<ILoadingScreenContext>()
                .FromFunction(c => new LoadingScreenContext(
                    c.Resolve<IShowUseCase>()
                    ));

            return container.Build();
        }
    }
}
