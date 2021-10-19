using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal
{
    public class ShipCollidedWithPointGoalUseCase : IShipCollidedWithPointGoalUseCase
    {
        public void Execute(PointGoalEntityView pointGoalEntityView)
        {
            UnityEngine.Debug.Log("Point!");
        }
    }
}
