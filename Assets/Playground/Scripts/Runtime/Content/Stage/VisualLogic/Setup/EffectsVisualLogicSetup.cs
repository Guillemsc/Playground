using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class EffectsVisualLogicSetup
    {
        public IReadOnlyList<EffectEntityView> Effects { get; }

        public EffectsVisualLogicSetup(
            IReadOnlyList<EffectEntityView> effects
            )
        {
            Effects = effects;
        }
    }
}
