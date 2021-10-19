using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class EffectsVisualLogicSetup
    {
        public float SpawnPercentageProbabiliby { get; }
        public IReadOnlyList<EffectEntityView> Effects { get; }

        public EffectsVisualLogicSetup(
            float spawnPercentageProbabiliby,
            IReadOnlyList<EffectEntityView> effects
            )
        {
            SpawnPercentageProbabiliby = spawnPercentageProbabiliby;
            Effects = effects;
        }
    }
}
