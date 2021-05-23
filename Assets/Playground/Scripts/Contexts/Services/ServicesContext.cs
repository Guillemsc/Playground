using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Services;

namespace Playground.Contexts
{
    public class ServicesContext : Context
    {
        public readonly static string SceneName = "ServicesContext";

        private TickablesService tickablesService;
        private TimeService timeService;

        protected override void Init()
        {
            ContextsProvider.Register(this);

            tickablesService = new TickablesService();
            ServicesProvider.Register(tickablesService);

            timeService = new TimeService();
            ServicesProvider.Register(timeService);
        }

        protected override void CleanUp()
        {
            ServicesProvider.Unregister(tickablesService);
            ServicesProvider.Unregister(timeService);

            ContextsProvider.Unregister(this);
        }
    }
}
