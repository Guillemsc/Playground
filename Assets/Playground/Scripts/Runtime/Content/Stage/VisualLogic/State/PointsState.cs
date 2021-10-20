namespace Playground.Content.Stage.VisualLogic.State
{
    public class PointsState
    {
        public int CurrentPoints { get; set; }

        public int LastCollectedPointIndex { get; set; } = -1;
        public int TotalSpawnedPoints { get; set; }
    }
}
