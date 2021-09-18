using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts.Meta
{
    public class MetaContext : Context
    {
        public readonly static string SceneName = "MetaContext";

        [SerializeField] private MetaContextReferences metaContextReferences;

        public MetaContextReferences MetaContextReferences => metaContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
