using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision
{
    public interface IShipCollidedWithDeadlyCollisionUseCase
    {
        void Execute(ShipEntityView shipEntityView);
    }
}
