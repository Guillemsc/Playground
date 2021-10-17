using Juce.CoreUnity.Factories;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct EffectEntityViewDefinition : MonoBehaviourUnknownPrefabFactoryDefinition<EffectEntityView>
    {
        public EffectEntityView Prefab { get; }

        public EffectEntityViewDefinition(
            EffectEntityView prefab
            )
        {
            Prefab = prefab;
        }
    }
}
