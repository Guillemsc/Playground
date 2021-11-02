using Juce.CoreUnity.Factories;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct CoinEntityViewDefinition : MonoBehaviourUnknownPrefabFactoryDefinition<CoinEntityView>
    {
        public CoinEntityView Prefab { get; }

        public CoinEntityViewDefinition(
            CoinEntityView prefab
            )
        {
            Prefab = prefab;
        }
    }
}
