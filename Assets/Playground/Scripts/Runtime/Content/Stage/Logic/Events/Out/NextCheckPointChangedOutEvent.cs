namespace Playground.Content.Stage.Logic.Events
{
    public class NextCheckPointChangedOutEvent
    {
        public int CheckPointIndex { get; }
        public int MaxCheckPointIndex { get; }

        public NextCheckPointChangedOutEvent(
            int checkPointIndex,
            int maxCheckPointIndex
            )
        {
            CheckPointIndex = checkPointIndex;
            MaxCheckPointIndex = maxCheckPointIndex;
        }
    }
}
