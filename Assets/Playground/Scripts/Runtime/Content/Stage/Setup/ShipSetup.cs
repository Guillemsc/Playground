using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.Setup
{
    public class ShipSetup
    {
        public ShipEntityView ShipEntityView { get; }
        public float ShipMaxSpeed { get; }

        public ShipSetup(
            ShipEntityView shipEntityView,
            float shipMaxSpeed
            )
        {
            ShipEntityView = shipEntityView;
            ShipMaxSpeed = shipMaxSpeed;
        }
    }
}
