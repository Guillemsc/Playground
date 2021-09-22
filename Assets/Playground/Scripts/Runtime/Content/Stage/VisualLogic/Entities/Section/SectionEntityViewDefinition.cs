using Juce.CoreUnity.Factories;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct SectionEntityViewDefinition : MonoBehaviourUnknownPrefabFactoryDefinition<SectionEntityView>
    {
        public string TypeId { get; }
        public SectionEntityView Prefab { get; }

        public SectionEntityViewDefinition(
            string typeId,
            SectionEntityView prefab
            )
        {
            TypeId = typeId;
            Prefab = prefab;
        }
    }
}
