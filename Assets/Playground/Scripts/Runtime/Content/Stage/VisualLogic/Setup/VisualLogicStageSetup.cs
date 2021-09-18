namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class VisualLogicStageSetup
    {
        public VisualLogicShipSetup ShipSetup { get; }

        public VisualLogicStageSetup(
            VisualLogicShipSetup shipSetup
            )
        {
            ShipSetup = shipSetup;
        }
    }
}
