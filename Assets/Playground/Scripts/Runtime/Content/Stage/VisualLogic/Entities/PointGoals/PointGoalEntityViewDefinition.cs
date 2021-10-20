namespace Playground.Content.Stage.VisualLogic.Entities
{
    public readonly struct PointGoalEntityViewDefinition 
    {
        public int PointValue { get; }

        public PointGoalEntityViewDefinition(
             int pointValue
            )
        {
            PointValue = pointValue;
        }
    }
}
