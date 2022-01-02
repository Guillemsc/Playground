using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Playground.Contexts.Cameras
{
    public static class CamerasContextInstaller
    {
        public static IDIContainer Install(
            CamerasContextInstance loadingScreenContextInstance
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind<ICamerasContext>()
                .FromFunction(c => new CamerasContext(
                    ));

            return container.Build();
        }
    }
}
