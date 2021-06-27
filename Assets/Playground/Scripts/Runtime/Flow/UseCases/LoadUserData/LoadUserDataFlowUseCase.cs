using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadUserDataFlowUseCase :  ILoadUserDataFlowUseCase
    {
        public Task Execute()
        {
            PersistenceService persistenceService = ServicesProvider.GetService<PersistenceService>();

            return persistenceService.LoadAll(default);
        }
    }
}
