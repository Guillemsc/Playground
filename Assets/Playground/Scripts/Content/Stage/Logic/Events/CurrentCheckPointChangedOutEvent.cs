namespace Playground.Content.Stage.Logic.Events
{
    public class CurrentCheckPointChangedOutEvent
    {
        public int CheckPointIndex { get; }
        public int MaxCheckPointIndex { get; }

        public CurrentCheckPointChangedOutEvent(
            int checkPointIndex,
            int maxCheckPointIndex
            )
        {
            CheckPointIndex = checkPointIndex;
            MaxCheckPointIndex = maxCheckPointIndex;
        }
    }
}
