using Juce.CoreUnity.Factories;

namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct PointGoalEntityViewDefinition 
    {
        public PointGoalEntityView Prefab { get; }

        public PointGoalEntityViewDefinition(
            PointGoalEntityView prefab
            )
        {
            Prefab = prefab;
        }
    }
}
