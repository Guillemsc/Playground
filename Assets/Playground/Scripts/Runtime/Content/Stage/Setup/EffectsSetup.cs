using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class EffectsSetup
    {
        public IReadOnlyList<EffectEntityView> Effects { get; }

        public EffectsSetup(
            IReadOnlyList<EffectEntityView> effects
            )
        {
            Effects = effects;
        }
    }
}
