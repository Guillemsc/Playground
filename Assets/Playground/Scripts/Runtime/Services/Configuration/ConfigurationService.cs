using Playground.Configuration.Stage;

namespace Playground.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public StageConfiguration StageConfiguration { get; }

        public ConfigurationService(
            StageConfiguration stageConfiguration
            )
        {
            StageConfiguration = stageConfiguration;
        }
    }
}
