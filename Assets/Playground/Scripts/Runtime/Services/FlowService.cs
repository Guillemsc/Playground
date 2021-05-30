using Juce.CoreUnity.Service;
using Playground.Flow.UseCases;

namespace Playground.Services
{
    public class FlowService : IService
    {
        public FlowUseCases FlowUseCases { get; set; }

        public FlowService(FlowUseCases flowUseCases)
        {
            FlowUseCases = flowUseCases;
        }

        public void Init()
        {

        }

        public void CleanUp()
        {

        }
    }
}
