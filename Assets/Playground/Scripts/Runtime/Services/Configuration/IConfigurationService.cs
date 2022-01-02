using Playground.Configuration.Stage;

namespace Playground.Services.Configuration
{
    public interface IConfigurationService
    {
        public StageConfiguration StageConfiguration { get; }
    }
}
