using Juce.Core.DI.Builder;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Time;
using JuceUnity.Core.DI.Extensions;
using Playground.Configuration.Stage;
using Playground.Services.Configuration;
using Playground.Services.Localization;
using Playground.Services.Persistence;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(
            this IDIContainerBuilder container,
            GameObject servicesGameObject,
            StageConfiguration stageConfiguration
            )
        {
            container.Bind<ITickablesService, TickablesService>()
                .FromGameObject(servicesGameObject);

            container.Bind<ITimeService, TimeService>()
                .FromGameObject(servicesGameObject);

            container.Bind<IUIViewStackService>()
                .FromInstance(new UIViewStackService());

            container.Bind<IConfigurationService>()
                .FromInstance(new ConfigurationService(stageConfiguration));

            container.Bind<IPersistenceService>()
                .FromInstance(new PersistenceService());

            container.Bind<ILocalizationService>()
                .FromInstance(new LocalizationService());

            container.Bind<ICheatsService>()
                .FromInstance(new CheatsService());
        }
    }
}
