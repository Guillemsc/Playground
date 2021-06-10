using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Services;
using Playground.Services.ViewStack;
using UnityEngine;

namespace Playground.Contexts
{
    public class ServicesContext : Context
    {
        public readonly static string SceneName = "ServicesContext";

        [SerializeField] private ServicesContextReferences servicesContextReferences = default;

        private TickablesService tickablesService;
        private TimeService timeService;
        private UIViewStackService uiViewStackService;
        private ConfigurationService configurationService;
        private UserService userService;

        protected override void Init()
        {
            ContextsProvider.Register(this);

            tickablesService = new TickablesService();
            ServicesProvider.Register(tickablesService);

            timeService = new TimeService();
            ServicesProvider.Register(timeService);

            uiViewStackService = new UIViewStackService(
                servicesContextReferences.UIFrameCanvas
                );
            ServicesProvider.Register(uiViewStackService);

            configurationService = new ConfigurationService(
                servicesContextReferences.CarLibrary,
                servicesContextReferences.DemoStagesConfiguration
                );
            ServicesProvider.Register(configurationService);

            userService = new UserService();
            ServicesProvider.Register(userService);
        }

        protected override void CleanUp()
        {
            ServicesProvider.Unregister(uiViewStackService);
            ServicesProvider.Unregister(tickablesService);
            ServicesProvider.Unregister(timeService);
            ServicesProvider.Unregister(configurationService);
            ServicesProvider.Unregister(userService);

            ContextsProvider.Unregister(this);
        }
    }
}
