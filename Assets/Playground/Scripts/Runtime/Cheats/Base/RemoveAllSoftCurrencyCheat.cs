using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Cheats
{
    public static class RemoveAllSoftCurrencyCheat
    {
        public static Task Execute(CancellationToken cancellationToken)
        {
            bool persistenceServiceFound = ServicesProvider.TryGetService(out PersistenceService persistenceService);

            if (!persistenceServiceFound)
            {
                return Task.CompletedTask;
            }

            persistenceService.ProgressDataSerializableData.Data.SoftCurrency = 0;

            return persistenceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
