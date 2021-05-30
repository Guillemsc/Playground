using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts
{
    public class LoadingScreenContext : Context
    {
        public readonly static string SceneName = "LoadingScreenContext";

        [SerializeField] private LoadingScreenContextReferences loadingScreenContextReferences;

        public LoadingScreenContextReferences LoadingScreenContextReferences => loadingScreenContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
        }
    }
}
