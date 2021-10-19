using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.Setup
{
    public class PointGoalsSetup
    {
        public float DistanceBetweenPointGoals { get; }
        public PointGoalEntityView Prefab { get; }

        public PointGoalsSetup(
            float distanceBetweenPointGoals,
            PointGoalEntityView prefab
            )
        {
            DistanceBetweenPointGoals = distanceBetweenPointGoals;
            Prefab = prefab;
        }
    }
}
