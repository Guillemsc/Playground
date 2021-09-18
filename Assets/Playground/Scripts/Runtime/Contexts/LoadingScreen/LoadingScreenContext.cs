using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts.LoadingScreen
{
    public class LoadingScreenContext : Context
    {
        [SerializeField] private LoadingScreenContextReferences loadingScreenContextReferences;

        public LoadingScreenContextReferences LoadingScreenContextReferences => loadingScreenContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
