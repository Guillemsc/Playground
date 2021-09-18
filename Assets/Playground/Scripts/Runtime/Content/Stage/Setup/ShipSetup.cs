using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.Setup
{
    public class ShipSetup
    {
        public ShipEntityView ShipEntityView { get; }

        public ShipSetup(
            ShipEntityView shipEntityView
            )
        {
            ShipEntityView = shipEntityView;
        }
    }
}
