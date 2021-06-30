using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;
using System;

namespace Playground.Shared.UseCases
{
    public class AddSoftCurrencyUseCase : IAddSoftCurrencyUseCase 
    {
        public void Execute(int toAdd)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            toAdd = Math.Max(toAdd, 0);

            progressData.SoftCurrency += toAdd;
        }
    }
}
