using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts.Cameras
{
    public class CamerasContext : Context
    {
        [SerializeField] private CamerasContextReferences camerasContextReferences;

        public CamerasContextReferences CamerasContextReferences => camerasContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
