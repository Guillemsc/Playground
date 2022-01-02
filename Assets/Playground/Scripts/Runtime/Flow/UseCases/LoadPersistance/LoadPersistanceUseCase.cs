using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadPersistance
{
    public class LoadPersistanceUseCase : ILoadPersistanceUseCase
    {
        public Task Execute()
        {
            //PersistenceService persistenceService = ServicesProvider.GetService<PersistenceService>();

            //return Task.WhenAll(
            //    persistenceService.UserDataSerializableData.Load(CancellationToken.None),
            //    persistenceService.ProgressDataSerializableData.Load(CancellationToken.None)
            //    );

            return Task.CompletedTask;
        }
    }
}
