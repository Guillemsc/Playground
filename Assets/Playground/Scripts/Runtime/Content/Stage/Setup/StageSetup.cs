namespace Playground.Content.Stage.Setup
{
    public class StageSetup
    {
        public ShipSetup ShipSetup { get; }

        public StageSetup(
            ShipSetup shipSetup
            )
        {
            ShipSetup = shipSetup;
        }
    }
}
