namespace Playground.Content.Stage.Setup
{
    public class StageSetup
    {
        public ShipSetup ShipSetup { get; }
        public SectionsSetup SectionsSetup { get; }
        public DirectionSelectorSetup DirectionSelectorSetup { get; }

        public StageSetup(
            ShipSetup shipSetup,
            SectionsSetup sectionsSetup,
            DirectionSelectorSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
