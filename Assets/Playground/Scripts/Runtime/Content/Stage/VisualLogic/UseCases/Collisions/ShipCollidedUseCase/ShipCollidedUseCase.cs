using Juce.CoreUnity.Physics;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollided
{
    public class ShipCollidedUseCase : IShipCollidedUseCase
    {
        private readonly IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase;

        public ShipCollidedUseCase(
            IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase
            )
        {
            this.shipCollidedWithDeadlyCollisionUseCase = shipCollidedWithDeadlyCollisionUseCase;
        }

        public void Execute(ShipEntityView shipEntityView, Collider2DData collider2DData)
        {
            DeadlyCollisionEntityView collisionEntityView = collider2DData.Collider2D.gameObject.GetComponentInParent<DeadlyCollisionEntityView>();
        
            if(collisionEntityView != null)
            {
                shipCollidedWithDeadlyCollisionUseCase.Execute(shipEntityView);

                return;
            }
        }
    }
}
