using Playground.Configuration.DemoStages;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class ServicesContextReferences
    {
        [Header("Configuration")]
        [SerializeField] private DemoStagesConfiguration demoStagesConfiguration = default;

        public DemoStagesConfiguration DemoStagesConfiguration => demoStagesConfiguration;
    }
}
