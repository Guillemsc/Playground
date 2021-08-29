using Juce.Core.Events;
using Juce.Core.Loading;
using Juce.Core.Sequencing;
using Juce.CoreUnity.Services;
using Playground.Services;
using Playground.Services.ViewStack;

namespace Playground.Content.Stage.VisualLogic.EntryPoint
{
    public class StageVisualLogicEntryPoint
    {
        public StageVisualLogicEntryPoint(
            ILoadingToken stageLoadedToken,
            IEventDispatcher eventDispatcher,
            IEventReceiver eventReceiver,
            TickablesService tickableService,
            TimeService timeService,
            UIViewStackService uiViewStackService,
            PersistenceService persistenceService
            )
        {
            Sequencer sequencer = new Sequencer();

            stageLoadedToken.Complete();
        }
    }
}
