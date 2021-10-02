namespace Playground.Content.Stage.Logic.Events
{
    public class ShipCollidedWithDeadlyCollisionInEvent
    {
        public int ShipInstanceId { get; }

        public ShipCollidedWithDeadlyCollisionInEvent(
            int shipInstanceId
            )
        {
            ShipInstanceId = shipInstanceId;
        }
    }
}
