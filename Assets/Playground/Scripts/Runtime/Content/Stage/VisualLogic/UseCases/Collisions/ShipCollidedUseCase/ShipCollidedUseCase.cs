using Juce.CoreUnity.Physics;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollided
{
    public class ShipCollidedUseCase : IShipCollidedUseCase
    {
        private readonly IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase;
        private readonly IShipCollidedWithEffectUseCase shipCollidedWithEffectUseCase;

        public ShipCollidedUseCase(
            IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase,
            IShipCollidedWithEffectUseCase shipCollidedWithEffectUseCase
            )
        {
            this.shipCollidedWithDeadlyCollisionUseCase = shipCollidedWithDeadlyCollisionUseCase;
            this.shipCollidedWithEffectUseCase = shipCollidedWithEffectUseCase;
        }

        public void Execute(ShipEntityView shipEntityView, Collider2DData collider2DData)
        {
            DeadlyCollisionEntityView collisionEntityView = collider2DData.Collider2D.gameObject.GetComponentInParent<DeadlyCollisionEntityView>();
        
            if(collisionEntityView != null)
            {
                shipCollidedWithDeadlyCollisionUseCase.Execute(shipEntityView);

                return;
            }

            EffectEntityView effectEntityView = collider2DData.Collider2D.gameObject.GetComponentInParent<EffectEntityView>();

            if (effectEntityView != null)
            {
                shipCollidedWithEffectUseCase.Execute(effectEntityView);

                return;
            }
        }
    }
}
