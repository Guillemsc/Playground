namespace Playground.Content.Stage.Logic.Setup
{
    public class LogicStageSetup
    {
        public LogicShipSetup ShipSetup { get; }

        public LogicStageSetup(
            LogicShipSetup shipSetup
            )
        {
            ShipSetup = shipSetup;
        }
    }
}
