using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal
{
    public interface IShipCollidedWithPointGoalUseCase
    {
        void Execute(PointGoalEntityView pointGoalEntityView);
    }
}
