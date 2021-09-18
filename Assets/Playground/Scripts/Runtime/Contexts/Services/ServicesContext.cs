using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Contexts.Services
{
    public class ServicesContext : Context
    {
        [SerializeField] private ServicesContextReferences servicesContextReferences = default;

        protected override void Init()
        {
            TickablesService tickablesService = new TickablesService();
            ServicesProvider.Register(tickablesService);
            AddCleanupAction(() => ServicesProvider.Unregister(tickablesService));

            TimeService timeService = new TimeService();
            ServicesProvider.Register(timeService);
            AddCleanupAction(() => ServicesProvider.Unregister(timeService));

            UIViewStackService uiViewStackService = new UIViewStackService(
                servicesContextReferences.UIFrameCanvas
                );
            ServicesProvider.Register(uiViewStackService);
            AddCleanupAction(() => ServicesProvider.Unregister(uiViewStackService));

            ConfigurationService configurationService = new ConfigurationService(
                servicesContextReferences.StageConfiguration
                );
            ServicesProvider.Register(configurationService);
            AddCleanupAction(() => ServicesProvider.Unregister(configurationService));

            PersistenceService userService = new PersistenceService();
            ServicesProvider.Register(userService);
            AddCleanupAction(() => ServicesProvider.Unregister(userService));

            LocalizationService localizationService = new LocalizationService();
            ServicesProvider.Register(localizationService);
            AddCleanupAction(() => ServicesProvider.Unregister(localizationService));

            ContextsProvider.Register(this);
            AddCleanupAction(() => ContextsProvider.Unregister(this));
        }

        //private PersistenceService userService;
        //private LocalizationService localizationService;

        //protected override void Init()
        //{
        //    ContextsProvider.Register(this);

        //    tickablesService = new TickablesService();
        //    ServicesProvider.Register(tickablesService);

        //    timeService = new TimeService();
        //    ServicesProvider.Register(timeService);

        //    uiViewStackService = new UIViewStackService(
        //        servicesContextReferences.UIFrameCanvas
        //        );
        //    ServicesProvider.Register(uiViewStackService);

        //    configurationService = new ConfigurationService(
        //        servicesContextReferences.CarLibrary,
        //        servicesContextReferences.DemoStagesConfiguration
        //        );
        //    ServicesProvider.Register(configurationService);

        //    userService = new PersistenceService();
        //    ServicesProvider.Register(userService);

        //    localizationService = new LocalizationService();
        //    ServicesProvider.Register(localizationService);
        //}

        //protected override void CleanUp()
        //{
        //    ServicesProvider.Unregister(uiViewStackService);
        //    ServicesProvider.Unregister(tickablesService);
        //    ServicesProvider.Unregister(timeService);
        //    ServicesProvider.Unregister(configurationService);
        //    ServicesProvider.Unregister(userService);
        //    ServicesProvider.Unregister(localizationService);

        //    ContextsProvider.Unregister(this);
        //}
    }
}
