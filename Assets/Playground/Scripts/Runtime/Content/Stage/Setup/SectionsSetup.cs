using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class SectionsSetup
    {
        public float DistanceBetweenSections { get; }
        public IReadOnlyList<SectionEntityView> Sections { get; }
        public float SpawnEffectProbabilty { get; }
        public float SpawnCoinProbabilty { get; }

        public SectionsSetup(
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
