using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.View.CheckPoints;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class CheckPointCrossedUseCase : ICheckPointCrossedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public CheckPointCrossedUseCase(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute(CheckPointView checkPointView)
        {
            eventDispatcher.Dispatch(new CheckPointCrossedInEvent(checkPointView.Index));
        }
    }
}
