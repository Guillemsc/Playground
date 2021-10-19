using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageSettings), menuName = "Playground/Settings/Stage/" + nameof(StageSettings), order = 1)]
    public class StageSettings : ScriptableObject
    {
        [Header("Timing")]
        [SerializeField, Min(0)] private float delayOnStageFinished = default;

        [Header("Sections")]
        [SerializeField, Min(0)] private float sectionsForwardSpawnDistance = default;
        [SerializeField, Min(0)] private float sectionsBackwardDespawnDistance = default;

        [Header("PointGoals")]
        [SerializeField, Min(0)] private float pointGoalsForwardSpawnDistance = default;
        [SerializeField, Min(0)] private float pointGoalsBackwardDespawnDistance = default;

        public float DelayOnStageFinished => delayOnStageFinished;

        public float SectionsForwardSpawnDistance => sectionsForwardSpawnDistance;
        public float SectionsBackwardDespawnDistance => sectionsBackwardDespawnDistance;

        public float PointGoalsForwardSpawnDistance => pointGoalsForwardSpawnDistance;
        public float PointGoalsBackwardDespawnDistance => pointGoalsBackwardDespawnDistance;
    }
}

