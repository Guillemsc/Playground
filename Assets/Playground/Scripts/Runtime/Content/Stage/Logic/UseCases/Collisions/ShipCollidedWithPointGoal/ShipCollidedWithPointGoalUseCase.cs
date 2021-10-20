using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.UseCases.ShipCollidedWithPointGoal
{
    public class ShipCollidedWithPointGoalUseCase : IShipCollidedWithPointGoalUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly StageState stageState;

        public ShipCollidedWithPointGoalUseCase(
            IEventDispatcher eventDispatcher,
            StageState stageState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.stageState = stageState;
        }

        public void Execute(int pointsAmmount)
        {
            stageState.CurrentPoints += pointsAmmount;

            eventDispatcher.Dispatch(new PointsChangedOutEvent(stageState.CurrentPoints));
        }
    }
}
