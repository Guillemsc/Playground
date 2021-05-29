using Juce.CoreUnity.Service;
using Playground.Configuration.DemoStages;

namespace Playground.Services
{
    public class ConfigurationService : IService
    {
        public DemoStagesConfiguration DemoStagesConfiguration { get; }

        public ConfigurationService(
            DemoStagesConfiguration demoStagesConfiguration
            )
        {
            DemoStagesConfiguration = demoStagesConfiguration;
        }

        public void Init()
        {
            
        }

        public void CleanUp()
        {
            
        }
    }
}
