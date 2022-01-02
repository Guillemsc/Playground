using Playground.Services.Localization;

namespace Assets.Playground.Scripts.Runtime.Cheats.Base.UseCases.SetNextLanguage
{
    public class SetNextLanguageUseCase : ISetNextLanguageUseCase
    {
        private readonly ILocalizationService localizationService;

        public SetNextLanguageUseCase(
            ILocalizationService localizationService
            )
        {
            this.localizationService = localizationService;
        }

        public void Execute()
        {
            int nextLanguageIndex = localizationService.CurrentLanguageIndex + 1;

            if (nextLanguageIndex >= localizationService.Languages.Count)
            {
                nextLanguageIndex = 0;
            }

            localizationService.SetLanguage(nextLanguageIndex);
        }
    }
}
