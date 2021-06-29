using Juce.CoreUnity.Service;
using Playground.Shared.UseCases;

namespace Playground.Services
{
    public class SharedService : IService
    {
        public SharedUseCases SharedUseCases { get; set; }

        public SharedService(SharedUseCases sharedUseCases)
        {
            SharedUseCases = sharedUseCases;
        }

        public void Init()
        {

        }

        public void CleanUp()
        {

        }
    }
}
