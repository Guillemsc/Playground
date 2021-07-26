using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;

namespace Playground.Shared.UseCases
{
    public class HasEnoughSoftCurrencyUseCase : IHasEnoughSoftCurrencyUseCase
    {
        public bool Execute(int value)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            if(progressData.SoftCurrency >= value)
            {
                return true;
            }

            return false;
        }
    }
}
