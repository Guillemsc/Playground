using Playground.Configuration.DemoStages;
using Playground.Libraries.Car;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class ServicesContextReferences
    {
        [Header("Configuration")]
        [SerializeField] private CarLibrary carLibrary = default;
        [SerializeField] private DemoStagesConfiguration demoStagesConfiguration = default;

        public CarLibrary CarLibrary => carLibrary;
        public DemoStagesConfiguration DemoStagesConfiguration => demoStagesConfiguration;
    }
}
