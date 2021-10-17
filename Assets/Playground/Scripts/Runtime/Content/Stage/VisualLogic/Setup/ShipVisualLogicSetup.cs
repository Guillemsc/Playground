using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class ShipVisualLogicSetup
    {
        public ShipEntityView ShipEntityView { get; }
        public float ShipMaxSpeed { get; }
        public float ShipRotationSpeed { get; }

        public ShipVisualLogicSetup(
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
