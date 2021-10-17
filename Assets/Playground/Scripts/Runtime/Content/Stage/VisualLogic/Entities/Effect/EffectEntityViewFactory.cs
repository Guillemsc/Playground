using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class EffectEntityViewFactory : MonoBehaviourUnknownPrefabFactory<EffectEntityViewDefinition, EffectEntityView>
    {
        public EffectEntityViewFactory(Transform parent) : base(parent)
        {

        }

        protected sealed override void Init(EffectEntityViewDefinition definition, EffectEntityView creation)
        {
         
        }
    }
}
