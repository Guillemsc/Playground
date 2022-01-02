using Assets.Playground.Scripts.Runtime.Cheats.Base.UseCases.SetNextLanguage;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Playground.Cheats;
using Playground.Services.Localization;

namespace Assets.Playground.Scripts.Runtime.Cheats.Base
{
    public static class BaseCheatsInstaller
    {
        public static BaseCheats Install(
            IDIContainer servicesContainer
            )
        {
            IDIContainerBuilder container = new DIContainerBuilder();

            container.Bind(servicesContainer);

            container.Bind<ISetNextLanguageUseCase>()
                .FromFunction(c => new SetNextLanguageUseCase(
                    c.Resolve<ILocalizationService>()
                    ));

            container.Bind<BaseCheats>()
                .FromFunction(c => new BaseCheats(
                    c.Resolve<ISetNextLanguageUseCase>()
                    ));

            IDIContainer finalContainer = container.Build();

            return finalContainer.Resolve<BaseCheats>();
        }
    }
}
