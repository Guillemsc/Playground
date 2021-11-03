using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class SectionsVisualLogicSetup
    {
        public float DistanceBetweenSections { get; }
        public IReadOnlyList<SectionEntityView> Sections { get; }
        public float SpawnEffectProbabilty { get; }
        public float SpawnCoinProbabilty { get; }

        public SectionsVisualLogicSetup(
            float distanceBetweenSections,
            IReadOnlyList<SectionEntityView> sections,
            float spawnEffectProbabilty,
            float spawnCoinProbabilty
            )
        {
            DistanceBetweenSections = distanceBetweenSections;
            Sections = sections;
            SpawnEffectProbabilty = spawnEffectProbabilty;
            SpawnCoinProbabilty = spawnCoinProbabilty;
        }
    }
}
