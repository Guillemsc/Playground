using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class PointGoalsVisualLogicSetup
    {
        public float DistanceBetweenPointGoals { get; }
        public PointGoalEntityView Prefab { get; }

        public PointGoalsVisualLogicSetup(
            float distanceBetweenPointGoals,
            PointGoalEntityView prefab
            )
        {
            DistanceBetweenPointGoals = distanceBetweenPointGoals;
            Prefab = prefab;
        }
    }
}
