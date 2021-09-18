namespace Playground.Content.Stage.Setup
{
    public class StageSetup
    {
        public ShipSetup ShipSetup { get; }
        public SectionsSetup SectionsSetup { get; }

        public StageSetup(
            ShipSetup shipSetup,
            SectionsSetup sectionsSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
        }
    }
}
