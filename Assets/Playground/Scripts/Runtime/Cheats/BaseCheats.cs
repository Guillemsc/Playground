using Juce.CoreUnity.Service;
using Playground.Services;
using System.ComponentModel;

namespace Playground.Cheats
{
    public class BaseCheats
    {
        [Category("Next Language")] 
        public void SetNextLanguage()
        {
            bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            if (!found)
            {
                return;
            }

            int nextLanguageIndex = localizationService.CurrentLanguageIndex + 1;

            if(nextLanguageIndex >= localizationService.Languages.Count)
            {
                nextLanguageIndex = 0;
            }

            localizationService.SetLanguage(nextLanguageIndex);
        }
    }
}
