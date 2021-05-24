using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class FinishLineCrossedUseCase : IFinishLineCrossedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly StageState stageState;
        private readonly CheckPointsState checkPointState;

        public FinishLineCrossedUseCase(
            IEventDispatcher eventDispatcher,
            StageState stageState,
            CheckPointsState checkPointState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.stageState = stageState;
            this.checkPointState = checkPointState;
        }

        public void Execute()
        {
            if(!checkPointState.AllCheckPointsCompleted)
            {
                return;
            }

            stageState.Completed = true;

            eventDispatcher.Dispatch(new StageFinishedOutEvent());
        }
    }
}
