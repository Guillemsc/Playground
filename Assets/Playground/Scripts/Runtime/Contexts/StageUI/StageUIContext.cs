using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    public class StageUIContext : Context
    {
        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public StageUIContextReferences StageUIContextReferences => stageUIContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }
    }
}
