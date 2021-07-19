using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;
using System;

namespace Playground.Shared.UseCases
{
    public class RemoveSoftCurrencyUseCase : IRemoveSoftCurrencyUseCase
    {
        public void Execute(int toRemove)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            toRemove = Math.Max(toRemove, 0);

            progressData.SoftCurrency -= toRemove;

            progressData.SoftCurrency = Math.Max(progressData.SoftCurrency, 0);
        }
    }
}
