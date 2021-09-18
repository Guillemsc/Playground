using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class VisualLogicShipSetup
    {
        public ShipEntityView ShipEntityView { get; }

        public VisualLogicShipSetup(
            ShipEntityView shipEntityView
            )
        {
            ShipEntityView = shipEntityView;
        }
    }
}
