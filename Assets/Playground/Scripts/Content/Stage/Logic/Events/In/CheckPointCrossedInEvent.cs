namespace Playground.Content.Stage.Logic.Events
{
    public class CheckPointCrossedInEvent
    {
        public int CheckPointIndex { get; }

        public CheckPointCrossedInEvent(int checkPointIndex)
        {
            CheckPointIndex = checkPointIndex;
        }
    }
}
