using Playground.Content.Stage.Setup;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class VisualLogicStageSetup
    {
        public VisualLogicShipSetup ShipSetup { get; }
        public VisualLogicSectionsSetup SectionsSetup { get; }

        public VisualLogicStageSetup(
            VisualLogicShipSetup shipSetup,
            VisualLogicSectionsSetup sectionsSetup
            )
        {
            ShipSetup = shipSetup;
            SectionsSetup = sectionsSetup;
        }
    }
}
