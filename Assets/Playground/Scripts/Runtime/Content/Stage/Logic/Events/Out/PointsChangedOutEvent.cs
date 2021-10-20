namespace Playground.Content.Stage.Logic.Events
{
    public class PointsChangedOutEvent
    {
        public int CurrentPoints { get; }

        public PointsChangedOutEvent(
            int currentPoints
            )
        {
            CurrentPoints = currentPoints;
        }
    }
}
