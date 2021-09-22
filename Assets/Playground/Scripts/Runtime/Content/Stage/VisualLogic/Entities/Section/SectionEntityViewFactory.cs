using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class SectionEntityViewFactory : MonoBehaviourUnknownPrefabFactory<SectionEntityViewDefinition, SectionEntityView>
    {
        public SectionEntityViewFactory(Transform parent) : base(parent)
        {

        }

        protected sealed override void Init(SectionEntityViewDefinition definition, SectionEntityView creation)
        {
            creation.Init(definition.TypeId);
        }
    }
}
