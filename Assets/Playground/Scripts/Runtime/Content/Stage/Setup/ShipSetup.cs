using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.Setup
{
    public class ShipSetup
    {
        public ShipEntityView ShipEntityView { get; }
        public float ShipMaxSpeed { get; }
        public float ShipRotationSpeed { get; }

        public ShipSetup(
            ShipEntityView shipEntityView,
            float shipMaxSpeed,
            float shipRotationSpeed
            )
        {
            ShipEntityView = shipEntityView;
            ShipMaxSpeed = shipMaxSpeed;
            ShipRotationSpeed = shipRotationSpeed;
        }
    }
}
