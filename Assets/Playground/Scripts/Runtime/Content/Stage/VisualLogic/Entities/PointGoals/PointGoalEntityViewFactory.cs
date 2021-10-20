using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public class PointGoalEntityViewFactory : MonoBehaviourKnownPrefabFactory<PointGoalEntityViewDefinition, PointGoalEntityView>
    {
        public PointGoalEntityViewFactory(
            PointGoalEntityView prefab,
            Transform parent
            ) : base(prefab, parent)
        {

        }

        protected sealed override void Init(PointGoalEntityViewDefinition definition, PointGoalEntityView creation)
        {
            creation.Init(definition.PointIndex);
        }
    }
}
