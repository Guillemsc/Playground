using Juce.CoreUnity.Service;
using Playground.Configuration.Stage;

namespace Playground.Services
{
    public class ConfigurationService : IService
    {
        public StageConfiguration StageConfiguration { get; }

        public ConfigurationService(
            StageConfiguration stageConfiguration
            )
        {
            StageConfiguration = stageConfiguration;
        }

        public void Init()
        {

        }

        public void CleanUp()
        {

        }
    }
}
