using Juce.CoreUnity.Physics;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollided
{
    public class ShipCollidedUseCase : IShipCollidedUseCase
    {
        private readonly IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase;
        private readonly IShipCollidedWithEffectUseCase shipCollidedWithEffectUseCase;
        private readonly IShipCollidedWithPointGoalUseCase shipCollidedWithPointGoalUseCase;

        public ShipCollidedUseCase(
            IShipCollidedWithDeadlyCollisionUseCase shipCollidedWithDeadlyCollisionUseCase,
            IShipCollidedWithEffectUseCase shipCollidedWithEffectUseCase,
            IShipCollidedWithPointGoalUseCase shipCollidedWithPointGoalUseCase
            )
        {
            this.shipCollidedWithDeadlyCollisionUseCase = shipCollidedWithDeadlyCollisionUseCase;
            this.shipCollidedWithEffectUseCase = shipCollidedWithEffectUseCase;
            this.shipCollidedWithPointGoalUseCase = shipCollidedWithPointGoalUseCase;
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

            PointGoalEntityView pointGoalEntityView = collider2DData.Collider2D.gameObject.GetComponentInParent<PointGoalEntityView>();

            if (pointGoalEntityView != null)
            {
                shipCollidedWithPointGoalUseCase.Execute(pointGoalEntityView);

                return;
            }
        }
    }
}
