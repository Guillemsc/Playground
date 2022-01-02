using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases.LoadLocalizationData
{
    public class LoadLocalizationDataUseCase : ILoadLocalizationDataUseCase
    {
        public async Task Execute()
        {
            //LocalizationService localizationService = ServicesProvider.GetService<LocalizationService>();

            //bool couldLoad = await localizationService.Load();

            //if (!couldLoad)
            //{
            //    UnityEngine.Debug.LogError($"Localization data could not be loaded, " +
            //        $"at {nameof(LoadLocalizationDataUseCase)}");
            //    return;
            //}

            //UnityEngine.Debug.Log($"Localization data successfully loaded");

            //localizationService.SetLanguage(LocalizationService.DefaultLanguage);
        }
    }
}
