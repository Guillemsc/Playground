using Juce.CoreUnity.Contexts;
using UnityEngine;

namespace Playground.Contexts
{
    public class StageUIContext : Context
    {
        public readonly static string SceneName = "StageUIContext";

        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public StageUIContextReferences StageUIContextReferences => stageUIContextReferences;

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
