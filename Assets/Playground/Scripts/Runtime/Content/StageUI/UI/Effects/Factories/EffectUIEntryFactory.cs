using Juce.CoreUnity.Factories;
using Playground.Content.StageUI.UI.Effects.Entries;

namespace Playground.Content.StageUI.UI.Effects.Factories
{
    public class EffectUIEntryFactory : MonoBehaviourKnownPrefabFactory<EffectUIEntryFactoryDefinition, EffectUIEntry>
    {
        public EffectUIEntryFactory(EffectUIEntry prefab) : base(prefab)
        {

        }

        protected override void Init(EffectUIEntryFactoryDefinition definition, EffectUIEntry creation)
        {
            creation.Init(
                definition.BackgroundSprite,
                definition.IconSprite
                );
        }
    }
}
