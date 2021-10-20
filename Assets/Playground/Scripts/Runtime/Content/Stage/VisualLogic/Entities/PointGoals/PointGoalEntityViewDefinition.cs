namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct PointGoalEntityViewDefinition 
    {
        public int PointIndex { get; }

        public PointGoalEntityViewDefinition(
             int pointIndex
            )
        {
            PointIndex = pointIndex;
        }
    }
}
