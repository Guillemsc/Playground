using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.State;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal
{
    public class ShipCollidedWithPointGoalUseCase : IShipCollidedWithPointGoalUseCase
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly PointsState pointsState;

        public ShipCollidedWithPointGoalUseCase(
            IEventDispatcher eventDispatcher,
            PointsState pointsState
            )
        {
            this.eventDispatcher = eventDispatcher;
            this.pointsState = pointsState;
        }

        public void Execute(PointGoalEntityView pointGoalEntityView)
        {
            if(pointGoalEntityView.PointIndex <= pointsState.LastCollectedPointIndex)
            {
                return;
            }

            pointsState.LastCollectedPointIndex = pointGoalEntityView.PointIndex;

            eventDispatcher.Dispatch(new ShipCollidedWithPointGoalInEvent(
                pointsAmmount: 1
                ));
        }
    }
}
