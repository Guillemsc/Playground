using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class FinishLineCrossedUseCase : IFinishLineCrossedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly CheckPointsState checkPointState;

        public FinishLineCrossedUseCase(
            IEventDispatcher eventDispatcher,
            CheckPointsState checkPointState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.checkPointState = checkPointState;
        }

        public void Execute()
        {
            if(!checkPointState.AllCheckPointsCompleted)
            {
                return;
            }

            eventDispatcher.Dispatch(new StageFinishedOutEvent());
        }
    }
}
