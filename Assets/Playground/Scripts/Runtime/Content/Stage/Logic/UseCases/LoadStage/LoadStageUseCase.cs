using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public LoadStageUseCase(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute()
        {
            eventDispatcher.Dispatch(new LoadStageOutEvent());
        }
    }
}
