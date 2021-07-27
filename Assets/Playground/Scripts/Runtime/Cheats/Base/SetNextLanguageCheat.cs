using Juce.CoreUnity.Service;
using Playground.Services;

namespace Playground.Cheats
{
    public static class SetNextLanguageCheat
    {
        public static void Execute()
        {
            bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            if (!found)
            {
                return;
            }

            int nextLanguageIndex = localizationService.CurrentLanguageIndex + 1;

            if (nextLanguageIndex >= localizationService.Languages.Count)
            {
                nextLanguageIndex = 0;
            }

            localizationService.SetLanguage(nextLanguageIndex);
        }
    }
}
