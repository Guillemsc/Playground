using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class SectionEntityViewFactory : MonoBehaviourFactory<SectionEntityViewDefinition, SectionEntityView>
    {
        public SectionEntityViewFactory(SectionEntityView prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected sealed override void Init(SectionEntityViewDefinition definition, SectionEntityView creation)
        {
            creation.Init(definition.InstanceId, definition.TypeId);
        }
    }
}
