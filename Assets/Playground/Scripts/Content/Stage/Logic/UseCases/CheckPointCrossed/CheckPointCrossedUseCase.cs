using Juce.Core.Events;
using Playground.Content.Stage.Logic.CheckPoints;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases
{
    public class CheckPointCrossedUseCase : ICheckPointCrossedUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly CheckPointRepository checkPointRepository;
        private readonly CheckPointsState checkPointState;

        public CheckPointCrossedUseCase(
            IEventDispatcher eventDispatcher,
            CheckPointRepository checkPointRepository,
            CheckPointsState checkPointState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.checkPointRepository = checkPointRepository;
            this.checkPointState = checkPointState;
        }

        public void Execute(int checkPointIndex)
        {
            bool found = checkPointRepository.TryGet(checkPointIndex, out CheckPoint checkPoint);

            if(!found)
            {
                return;
            }

            if(checkPointState.CurrentCheckPointIndex + 1 != checkPointIndex)
            {
                return;
            }

            int nextCheckPointIndex = checkPointIndex + 1;

            checkPointState.CurrentCheckPointIndex = checkPointIndex;

            int maxCheckPointIndex = checkPointRepository.Items.Count - 1;

            eventDispatcher.Dispatch(new CurrentCheckPointChangedOutEvent(checkPointIndex, maxCheckPointIndex));

            if(nextCheckPointIndex <= maxCheckPointIndex)
            {
                eventDispatcher.Dispatch(new NextCheckPointChangedOutEvent(nextCheckPointIndex, maxCheckPointIndex));
            }

            if (checkPointIndex == maxCheckPointIndex)
            {
                checkPointState.AllCheckPointsCompleted = true;
            }
        }
    }
}
