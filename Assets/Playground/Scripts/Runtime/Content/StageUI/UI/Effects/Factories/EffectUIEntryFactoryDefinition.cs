using UnityEngine;

namespace Playground.Content.StageUI.UI.Effects.Factories
{
    public class EffectUIEntryFactoryDefinition 
    {
        public Sprite BackgroundSprite { get; }
        public Sprite IconSprite { get; }

        public EffectUIEntryFactoryDefinition(
            Sprite backgroundSprite,
            Sprite iconSprite
            )
        {
            BackgroundSprite = backgroundSprite;
            IconSprite = iconSprite;
        }
    }
}
