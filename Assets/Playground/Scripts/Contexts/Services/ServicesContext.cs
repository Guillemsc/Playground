using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Services;
using Playground.Utils.UIViewStack;
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

        protected override void Init()
        {
            ContextsProvider.Register(this);

            tickablesService = new TickablesService();
            ServicesProvider.Register(tickablesService);

            timeService = new TimeService();
            ServicesProvider.Register(timeService);

            uiViewStackService = new UIViewStackService();
            ServicesProvider.Register(uiViewStackService);

            configurationService = new ConfigurationService(
                servicesContextReferences.DemoStagesConfiguration
                );
            ServicesProvider.Register(configurationService);
        }

        protected override void CleanUp()
        {
            ServicesProvider.Unregister(uiViewStackService);
            ServicesProvider.Unregister(tickablesService);
            ServicesProvider.Unregister(timeService);

            ContextsProvider.Unregister(this);
        }
    }
}
