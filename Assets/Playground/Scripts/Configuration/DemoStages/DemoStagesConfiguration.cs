using Playground.Content.Stage.Configuration;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Configuration.DemoStages
{
    [CreateAssetMenu(fileName = "DemoStagesConfiguration", menuName = "Playground/DemoStagesConfiguration", order = 1)]
    public class DemoStagesConfiguration : ScriptableObject
    {
        [SerializeField] private List<StageConfiguration> stageConfigurations = default;

        public IReadOnlyList<StageConfiguration> StageConfigurations => stageConfigurations;
    }
}
