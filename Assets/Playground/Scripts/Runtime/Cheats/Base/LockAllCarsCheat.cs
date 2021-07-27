using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Cheats
{
    public static class LockAllCarsCheat
    {
        public static Task Execute(CancellationToken cancellationToken)
        {
            bool persistenceServiceFound = ServicesProvider.TryGetService(out PersistenceService persistenceService);

            if (!persistenceServiceFound)
            {
                return Task.CompletedTask;
            }

            persistenceService.ProgressDataSerializableData.Data.OwnedCars.Clear();

            return persistenceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
