using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Cheats
{
    public static class AddSoftCurrencyCheat
    {
        public static Task Execute(CancellationToken cancellationToken)
        {
            bool persistenceServiceFound = ServicesProvider.TryGetService(out PersistenceService persistenceService);

            if (!persistenceServiceFound)
            {
                return Task.CompletedTask;
            }

            persistenceService.ProgressDataSerializableData.Data.SoftCurrency += 1000;

            return persistenceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
