using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = nameof(SectionsConfiguration), menuName = "Playground/Configuration/Stage/" + nameof(SectionsConfiguration), order = 1)]
    public class SectionsConfiguration : ScriptableObject
    {
        [SerializeField, Min(0)] private float distanceBetweenSections = default;
        [SerializeField] private List<SectionEntityView> sectionEntityViews = default;

        [Header("Spawn elements probabilities")]
        [SerializeField, Range(0, 100)] private float spawnEffectProbabilty = default;
        [SerializeField, Range(0, 100)] private float spawnCoinProbabilty = default;

        public SectionsSetup ToSetup()
        {
            return new SectionsSetup(
                distanceBetweenSections,
                sectionEntityViews,
                spawnEffectProbabilty,
                spawnCoinProbabilty
                );
        }
    }
}
