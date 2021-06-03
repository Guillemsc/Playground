using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private IEventDispatcher eventDispatcher;
        private StageState stageState;

        public StartStageUseCase(
            IEventDispatcher eventDispatcher,
            StageState stageState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.stageState = stageState;
        }

        public void Execute()
        {
            if(stageState.Started)
            {
                return;
            }

            stageState.Started = true;

            eventDispatcher.Dispatch(new StartStageOutEvent());
        }
    }
}
