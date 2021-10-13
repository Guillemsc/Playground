using Playground.Content.Stage.Setup;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class StageVisualLogicSetup
    {
        public ShipVisualLogicSetup ShipSetup { get; }
        public SectionsVisualLogicSetup SectionsSetup { get; }
        public DirectionSelectorSetup DirectionSelectorSetup { get; }

        public StageVisualLogicSetup(
            ShipVisualLogicSetup shipSetup,
            SectionsVisualLogicSetup sectionsSetup,
            DirectionSelectorSetup directionSelectorSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
            DirectionSelectorSetup = directionSelectorSetup;
        }
    }
}
