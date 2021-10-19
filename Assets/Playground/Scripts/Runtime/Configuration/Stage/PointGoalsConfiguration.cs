using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(PointGoalsConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(PointGoalsConfiguration), order = 1)]
    public class PointGoalsConfiguration : ScriptableObject
    {
        [SerializeField, Min(0)] private float distanceBetweenPointGoals = default;
        [SerializeField] private PointGoalEntityView prefab = default;

        public PointGoalsSetup ToSetup()
        {
            return new PointGoalsSetup(
                distanceBetweenPointGoals,
                prefab
                );
        }
    }
}
