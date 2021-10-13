namespace Playground.Content.Stage.Logic.Setup
{
    public class StageLogicSetup
    {
        public ShipLogicSetup ShipSetup { get; }

        public StageLogicSetup(
            ShipLogicSetup shipSetup
            )
        {
            ShipSetup = shipSetup;
        }
    }
}
