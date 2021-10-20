using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.StageUI.UI.Points;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal
{
    public class ShipCollidedWithPointGoalUseCase : IShipCollidedWithPointGoalUseCase
    {
        private readonly PointsState pointsState;
        private readonly IPointsUIInteractor pointsUIInteractor;

        public ShipCollidedWithPointGoalUseCase(
            PointsState pointsState,
            IPointsUIInteractor pointsUIInteractor
            )
        {
            this.pointsState = pointsState;
            this.pointsUIInteractor = pointsUIInteractor;
        }

        public void Execute(PointGoalEntityView pointGoalEntityView)
        {
            if(pointsState.CurrentPoints >= pointGoalEntityView.PointValue)
            {
                return;
            }

            pointsState.CurrentPoints = pointGoalEntityView.PointValue;

            pointsUIInteractor.SetPoints(pointsState.CurrentPoints);
        }
    }
}
