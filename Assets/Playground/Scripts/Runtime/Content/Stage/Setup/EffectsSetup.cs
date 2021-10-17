using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class EffectsSetup
    {
        public float SpawnPercentageProbabiliby { get; }
        public IReadOnlyList<EffectEntityView> Effects { get; }

        public EffectsSetup(
            float spawnPercentageProbabiliby,
            IReadOnlyList<EffectEntityView> effects
            )
        {
            SpawnPercentageProbabiliby = spawnPercentageProbabiliby;
            Effects = effects;
        }
    }
}
