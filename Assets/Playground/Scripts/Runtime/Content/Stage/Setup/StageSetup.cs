namespace Playground.Content.Stage.Setup
{
    public class StageSetup
    {
        public ShipSetup ShipSetup { get; }
        public SectionsSetup SectionsSetup { get; }
        public PointGoalsSetup PointGoalsSetup { get; }
        public EffectsSetup EffectsSetup { get; }
        public DirectionSelectorSetup DirectionSelectorSetup { get; }

        public StageSetup(
            ShipSetup shipSetup,
            SectionsSetup sectionsSetup,
            PointGoalsSetup pointGoalsSetup,
            EffectsSetup effectsSetup,
            DirectionSelectorSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            PointGoalsSetup = pointGoalsSetup;
            EffectsSetup = effectsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
