namespace Playground.Content.Stage.Logic.Events
{
    public class ShipCollidedWithPointGoalInEvent
    {
        public int PointsAmmount { get; }

        public ShipCollidedWithPointGoalInEvent(
            int pointsAmmount
            )
        {
            PointsAmmount = pointsAmmount;
        }
    }
}
