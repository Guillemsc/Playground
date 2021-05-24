using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class FinishLineCrossedUseCase : IFinishLineCrossedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public FinishLineCrossedUseCase(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute(FinishLineView finishLineView)
        {
            eventDispatcher.Dispatch(new FinishLineCrossedInEvent());
        }
    }
}
