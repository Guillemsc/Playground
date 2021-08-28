using Juce.CoreUnity.Service;
using Playground.Configuration.Car;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Cheats
{
    public static class UnlockAllCarsCheat
    {
        public static Task Execute(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
            //bool configurationServiceFound = ServicesProvider.TryGetService(out ConfigurationService configurationService);

            //if (!configurationServiceFound)
            //{
            //    return Task.CompletedTask;
            //}

            //bool persistenceServiceFound = ServicesProvider.TryGetService(out PersistenceService persistenceService);

            //if (!persistenceServiceFound)
            //{
            //    return Task.CompletedTask;
            //}

            //foreach(CarConfiguration carConfiguration in configurationService.CarLibrary.Items)
            //{
            //    bool alreadyUnlocked = persistenceService.ProgressDataSerializableData.Data.OwnedCars.Contains(
            //        carConfiguration.CarTypeId
            //        );

            //    if(alreadyUnlocked)
            //    {
            //        continue;
            //    }

            //    persistenceService.ProgressDataSerializableData.Data.OwnedCars.Add(carConfiguration.CarTypeId);
            //}

            //return persistenceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
