using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;

namespace Playground.Contexts.Meta
{
    public static class MetaContextInstaller
    {
        public static IDIContainer Install(
            MetaContextInstance metaContextInstance
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind<IMetaContext>()
                .FromFunction(c => new MetaContext(
                    ));

            return container.Build();
        }
    }
}
