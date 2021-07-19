using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;
using System.Collections.Generic;

namespace Playground.Shared.UseCases
{
    public class GetOwnedCarsUseCase : IGetOwnedCarsUseCase
    {
        public List<string> Execute()
        {
            List<string> ret = new List<string>();

            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            ret.AddRange(progressData.OwnedCars);

            return ret;
        }
    }
}
