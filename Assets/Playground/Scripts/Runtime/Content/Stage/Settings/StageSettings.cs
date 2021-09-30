using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(StageSettings), menuName = "Playground/Settings/Stage/" + nameof(StageSettings), order = 1)]
    public class StageSettings : ScriptableObject
    {
        [Header("Sections")]
        [SerializeField, Min(0)] private float sectionsForwardSpawnDistance = default;
        [SerializeField, Min(0)] private float sectionsBackwardDespawnDistance = default;

        public float SectionsForwardSpawnDistance => sectionsForwardSpawnDistance;
        public float SectionsBackwardDespawnDistance => sectionsBackwardDespawnDistance;
    }
}

