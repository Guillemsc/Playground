using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.CoreUnity.Contexts;
using Playground.Content.Meta.Installers;
using UnityEngine;

namespace Playground.Contexts.Meta
{
    public class MetaContext : Context
    {
        [SerializeField] private MetaContextReferences metaContextReferences;

        public MetaContextReferences MetaContextReferences => metaContextReferences;

        protected override void Init()
        {
            IDIContainerBuilder containerBuilder = new DIContainerBuilder();

            containerBuilder.Bind(new ServicesInstaller());
            containerBuilder.Bind(metaContextReferences.StageEndUIInstaller);

            IDIContainer container = containerBuilder.Build();
            AddCleanupAction(container.Dispose);

            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
